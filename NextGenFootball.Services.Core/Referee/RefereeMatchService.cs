using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Referee.Interfaces;
using NextGenFootball.Web.ViewModels.Referee.RefereeMatches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Referee
{
    public class RefereeMatchService : IRefereeMatchService
    {
        private readonly IMatchRepository matchRepository;
        private readonly IRefereeRepository refereeRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly IMatchReportRepository matchReportRepository;
        private readonly UserManager<ApplicationUser> userManager;  
        public RefereeMatchService(IMatchRepository matchRepository,UserManager<ApplicationUser> userManager
            ,IRefereeRepository refereeRepository, IPlayerRepository playerRepository
            , IMatchReportRepository matchReportRepository)
        {
            this.matchRepository = matchRepository;
            this.userManager = userManager;
            this.refereeRepository = refereeRepository;
            this.playerRepository = playerRepository;
            this.matchReportRepository = matchReportRepository;
        }

        public async Task CreateMatchReportAsync(MatchReportViewModel matchReport)
        {
            var report = new MatchReport
            {
                Id = Guid.NewGuid(),
                MatchId = matchReport.MatchId,
                HomeScore = matchReport.HomeScore,
                AwayScore = matchReport.AwayScore,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = matchReport.RefereeName,
            };

            var events = matchReport.FirstHalfHomeEvents
                .Select(e => new { e.Minute, e.PlayerId, e.StatType, Half = 1, Team = "Home" })
                .Concat(matchReport.FirstHalfAwayEvents.Select(e => new { e.Minute, e.PlayerId, e.StatType, Half = 1, Team = "Away" }))
                .Concat(matchReport.SecondHalfHomeEvents.Select(e => new { e.Minute, e.PlayerId, e.StatType, Half = 2, Team = "Home" }))
                .Concat(matchReport.SecondHalfAwayEvents.Select(e => new { e.Minute, e.PlayerId, e.StatType, Half = 2, Team = "Away" }))
                .ToList();

            report.Events = events.Select(e => new MatchEvent
            {
                Minute = e.Minute,
                PlayerId = e.PlayerId,
                StatType = e.StatType,
                Half = e.Half,
                Team = e.Team,
                MatchReportId = report.Id
            }).ToList();

            await this.matchReportRepository.AddAsync(report);

            foreach (var e in events)
            {
                var player = await this.playerRepository.GetByIdAsync(e.PlayerId);
                if (player != null)
                {
                    switch (e.StatType)
                    {
                        case "Goal":
                            player.Goals += 1;
                            break;
                        case "Assist":
                            player.Assists += 1;
                            break;
                        case "Yellow Card":
                            player.YellowCards += 1;
                            break;
                        case "Red Card":
                            player.RedCards += 1;
                            break;
                    }
                    await this.playerRepository.UpdateAsync(player);
                }
            }

            var match = await this.matchRepository.GetByIdAsync(matchReport.MatchId);
            if (match != null)
            {
                match.HomeScore = matchReport.HomeScore;
                match.AwayScore = matchReport.AwayScore;
                match.MatchReportId = report.Id;
                await this.matchRepository.UpdateAsync(match);

            }
        }

        public async Task<MatchReportViewModel?> GetMatchReportView(long matchId)
        {
            Match? match = await this.matchRepository
                .GetAllAttached()
                .Include(m => m.HomeTeam)
                .ThenInclude(m => m.Players)
                .Include(m => m.AwayTeam)
                .ThenInclude(m => m.Players)
                .Include(m => m.Referee)
                .FirstOrDefaultAsync(m => m.Id == matchId && !m.IsDeleted);
            MatchReportViewModel? matchReport = null;
            if (match!=null)
            {
               matchReport = new MatchReportViewModel
                {
                    MatchId = matchId,
                    HomePlayers = match.HomeTeam.Players.Select(p => new PlayerSimpleDto()
                    {
                        PlayerId = p.Id,
                        PlayerName = $"{p.FirstName} {p.LastName}",
                        PlayerImageUrl = p.ImageUrl
                    }).ToList(),
                    AwayPlayers = match.AwayTeam.Players.Select(p => new PlayerSimpleDto()
                    {
                        PlayerId = p.Id,
                        PlayerName = $"{p.FirstName} {p.LastName}",
                        PlayerImageUrl = p.ImageUrl

                    }).ToList(),
                    HomeScore = match.HomeScore ?? 0,
                    AwayScore = match.AwayScore ?? 0,
                    RefereeName = match.Referee != null ? $"{match.Referee.FirstName} {match.Referee.LastName}" : "N/A",
               };
            }
            return matchReport;
        }

        public async Task<IEnumerable<MyMatchesViewModel?>> GetRefereeMatches(Guid? id)
        {
            
            IEnumerable<MyMatchesViewModel?> matches = this.matchRepository
                .GetAllAttached()
                .Include(m=>m.Referee)
                .Include(m => m.AssistantReferee1)
                .Include(m => m.AssistantReferee2)
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Stadium)
                .Include(m => m.League)
                .Where(m => m.Referee!.ApplicationUserId == id
                 || m.AssistantReferee1!.ApplicationUserId == id
                 || m.AssistantReferee2!.ApplicationUserId == id)
                .Select(m => new MyMatchesViewModel
                {
                    MatchId=m.Id,
                    Date=m.Date,
                    HomeTeamName= m.HomeTeam.Name,
                    HomeTeamImageUrl=m.HomeTeam.ImageUrl,
                    AwayTeamName = m.AwayTeam.Name,
                    AwayTeamImageUrl = m.AwayTeam.ImageUrl,
                    StadiumName = m.Stadium.Name,
                    LeagueName = m.League.Name,
                    RefereeName = m.Referee != null ? $"{m.Referee.FirstName} {m.Referee.LastName}" : "N/A",
                    AssistantReferee1Name = m.AssistantReferee1 != null ? $"{m.AssistantReferee1.FirstName} {m.AssistantReferee1.LastName}" : "N/A",
                    AssistantReferee2Name = m.AssistantReferee2 != null ? $"{m.AssistantReferee2.FirstName} {m.AssistantReferee2.LastName}" : "N/A",
                    MyRole= m.Referee!.ApplicationUserId == id ? "Main Referee" :
                            m.AssistantReferee1!.ApplicationUserId == id ? "AR 1" :
                            m.AssistantReferee2!.ApplicationUserId == id ? "AR 2" : "Unknown",
                    Status=m.Status,
                    HasReport= m.MatchReportId != null,
                });
            return matches;
        }
    }
}
