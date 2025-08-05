using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Match;
using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.GCommon.ApplicationConstants   ;

namespace NextGenFootball.Services.Core
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository matchRepository;
        private readonly ITeamRepository teamRepository;
        private readonly ILeagueRepository leagueRepository;
        private readonly IStadiumRepository stadiumRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly ITeamStartingLineupRepository teamStartingLineupRepository;
        public MatchService(IMatchRepository matchRepository, IPlayerRepository playerRepository, ITeamRepository teamRepository, ILeagueRepository leagueRepository, IStadiumRepository stadiumRepository, ITeamStartingLineupRepository teamStartingLineupRepository)
        {
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
            this.leagueRepository = leagueRepository;
            this.stadiumRepository = stadiumRepository;
            this.playerRepository = playerRepository;
            this.teamStartingLineupRepository = teamStartingLineupRepository;
        }

        public async Task<bool> CreateMatchAsync(MatchCreateViewModel model,int? id)
        {
            bool res = false;
            Team? homeTeam=await this.teamRepository.GetAllAttached()
                .Include(t=>t.Stadium)
                .SingleOrDefaultAsync(t => t.Id == model.HomeTeamId);
            Team? awayTeam=await this.teamRepository.SingleOrDefaultAsync(t => t.Id == model.AwayTeamId);
            League? league = await this.leagueRepository.SingleOrDefaultAsync(l => l.Id == id);
            bool isValidDate = model.Date > DateTime.Now;
            if (homeTeam != null && awayTeam != null && league != null && isValidDate)
            {
                Match match = new Match
                {
                    HomeTeamId = homeTeam.Id,
                    AwayTeamId = awayTeam.Id,
                    Date = model.Date,
                    StadiumId = homeTeam.Stadium.Id,
                    LeagueId = league.Id,
                    Status = MatchStatus.Scheduled,
                    Round = model.Round,

                };
                await this.matchRepository.AddAsync(match);
                res = true;
            }
            return res;

        }

        public async Task<IEnumerable<MatchIndexViewModel>> GetAllMatchesAsync()
        {
            IEnumerable<MatchIndexViewModel> matches = await this.matchRepository
                .GetAllAttached()
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.League)
                .Include(m => m.Stadium)
                .AsNoTracking()
                .Select(m => new MatchIndexViewModel
                {
                    Id = m.Id,
                    HomeTeamId = m.HomeTeamId,
                    HomeTeamName = m.HomeTeam.Name,
                    HomeTeamImageUrl = m.HomeTeam.ImageUrl,
                    AwayTeamId = m.AwayTeamId,
                    AwayTeamName = m.AwayTeam.Name,
                    AwayTeamImageUrl = m.AwayTeam.ImageUrl,
                    Date = m.Date,
                    HomeScore = m.HomeScore,
                    AwayScore = m.AwayScore,
                    StadiumName = m.Stadium.Name,
                    Status = m.Status,
                    IsPlayed=m.Status == MatchStatus.Played,


                })
                .ToListAsync();

            return matches;
        }

        public async Task<MatchDetailsViewModel?> GetMatchDetailsAsync(long? id)
        {
            MatchDetailsViewModel? match = null;
            if (id.HasValue)
            {
                var matchEntity = await this.matchRepository
            .GetAllAttached()
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .Include(m => m.League)
            .Include(m => m.Stadium)
            .Include(m => m.Report)
                .ThenInclude(r => r.Events)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id.Value);

                if (matchEntity == null)
                    return null;

                // Map match details
                match = new MatchDetailsViewModel
                {
                    HomeTeamName = matchEntity.HomeTeam.Name,
                    HomeTeamImageUrl = matchEntity.HomeTeam.ImageUrl,
                    AwayTeamName = matchEntity.AwayTeam.Name,
                    AwayTeamImageUrl = matchEntity.AwayTeam.ImageUrl,
                    Date = matchEntity.Date,
                    HomeScore = matchEntity.HomeScore,
                    AwayScore = matchEntity.AwayScore,
                    StadiumId = matchEntity.Stadium.Id,
                    StadiumName = matchEntity.Stadium.Name,
                    LeagueName = matchEntity.League.Name,
                    IsPlayed = matchEntity.Status == MatchStatus.Played,
                    VideoUrl = matchEntity.VideoUrl,
                    Events = matchEntity.Report != null
                        ? matchEntity.Report.Events.Select(e => new MatchEventViewModel
                        {
                            Minute = e.Minute,
                            PlayerId = e.PlayerId,
                            PlayerName = this.playerRepository.GetAllAttached()
                                .Where(p => p.Id == e.PlayerId)
                                .Select(p => $"{p.FirstName} {p.LastName}")
                                .FirstOrDefault() ?? "Unknown",
                            StatType = e.StatType.ToString(),
                            Team = e.Team,
                            PlayerImageUrl = this.playerRepository.GetAllAttached()
                                .Where(p => p.Id == e.PlayerId)
                                .Select(p => p.ImageUrl)
                                .FirstOrDefault() ?? $"/images/{NoImagePeopleUrl}",
                        }).ToList()
                        : new List<MatchEventViewModel>()
                };

                match.HomeTeamLineup = await GetLineupAsync(matchEntity.HomeTeam.Id) ?? new LineupViewModel();
                match.AwayTeamLineup = await GetLineupAsync(matchEntity.AwayTeam.Id) ?? new LineupViewModel();
            }
            return match;
        }
        public async Task<LineupViewModel?> GetLineupAsync(int teamId)
        {
            var lineupEntity = await teamStartingLineupRepository
                .GetAllAttached()
                .Include(l => l.Players)
                .FirstOrDefaultAsync(l => l.TeamId == teamId);

            if (lineupEntity == null)
                return null;

            // Fetch all player IDs in this lineup
            var playerIds = lineupEntity.Players.Select(lp => lp.PlayerId).ToList();

            // Fetch player details in bulk
            var players = await playerRepository
                .GetAllAttached()
                .Where(p => playerIds.Contains(p.Id))
                .ToListAsync();

            // Map each lineup player to the view model
            var lineupPlayers = lineupEntity.Players
                .Select(lp =>
                {
                    var player = players.FirstOrDefault(p => p.Id == lp.PlayerId);
                    return new LineupPlayerViewModel
                    {
                        PlayerName = player != null ? $"{player.FirstName} {player.LastName}" : "Unknown",
                        PositionName = lp.PositionName,
                        ImageUrl = player?.ImageUrl ?? "/images/default-player.png"
                    };
                })
                .ToList();

            return new LineupViewModel
            {
                FormationName = lineupEntity.FormationName,
                Players = lineupPlayers
            };
        }

    }
}
