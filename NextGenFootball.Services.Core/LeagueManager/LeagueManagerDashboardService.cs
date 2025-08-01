using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.LeagueManager.Interfaces;
using NextGenFootball.Web.ViewModels.Referee.RefereeAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.LeagueManager
{
    public class LeagueManagerDashboardService : ILeagueManagerDashboardService
    {
        private readonly IMatchRepository matchRepository;
        private readonly IRefereeRepository refereeRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly ILeagueRepository leagueRepository;
        public LeagueManagerDashboardService(IMatchRepository matchRepository
            , IRefereeRepository refereeRepository, IPlayerRepository playerRepository,
            ILeagueRepository leagueRepository
            )
        {
            this.matchRepository = matchRepository;
            this.refereeRepository = refereeRepository;
            this.playerRepository = playerRepository;
            this.leagueRepository = leagueRepository;
        }

        public async Task<bool> AssignRefereeToMatchAsync(AssignRefereeViewModel model)
        {
            bool res=false;
            Match? match=await this.matchRepository
                .FirstOrDefaultAsync(m => m.Id == model.MatchId && m.LeagueId == model.LeagueId && !m.IsDeleted);
            if (match != null) 
            {
                match.RefereeId = model.MainRefereeId;
                match.AssistantReferee1Id = model.AssistantReferee1Id;
                match.AssistantReferee2Id = model.AssistantReferee2Id;
                await this.matchRepository.UpdateAsync(match);
                res = true;
            }
            return res;

        }

        public async Task<AssignRefereeViewModel> GetMatchDetailsForAssignment(long matchId, int leagueId)
        {
            AssignRefereeViewModel model = new AssignRefereeViewModel();
            League? league = await this.leagueRepository
                .SingleOrDefaultAsync(l => l.Id == leagueId);
            if (league != null)
            {
                Match? match = await this.matchRepository
                    .GetAllAttached()
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .Include(m => m.Referee)
                    .Include(m => m.AssistantReferee1)
                    .Include(m => m.AssistantReferee2)
                    .SingleOrDefaultAsync(m => m.Id == matchId && m.LeagueId == leagueId && !m.IsDeleted);
                if (match != null)
                {
                    List<FreeRefereeModel> availableReferees = await this.refereeRepository
                        .GetAllAttached()
                        .Select(r => new FreeRefereeModel
                        {
                            Id = r.Id,
                            Name = $"{r.FirstName} {r.LastName}"
                        }).ToListAsync();
                    model = new AssignRefereeViewModel
                    {
                        LeagueId = league.Id,
                        MatchId = match.Id,
                        HomeTeam = match.HomeTeam.Name,
                        HomeTeamImageUrl = match.HomeTeam.ImageUrl,
                        AwayTeam = match.AwayTeam.Name,
                        AwayTeamImageUrl = match.AwayTeam.ImageUrl,
                        Date = match.Date,
                        AvailableReferees = availableReferees,
                        MainRefereeId = match.Referee?.Id,
                        AssistantReferee1Id = match.AssistantReferee1?.Id,
                        AssistantReferee2Id = match.AssistantReferee2?.Id
                    };
                }
            }
            return model;
        }

        public async Task<RefereeAssignmentsIndexViewModel> GetMatchesForAssignment(int id)
        {
            RefereeAssignmentsIndexViewModel model = new RefereeAssignmentsIndexViewModel();
            League? league=await this.leagueRepository
                .SingleOrDefaultAsync(l => l.Id == id);
            if (league != null)
            {
                model.LeagueId = league.Id;
                model.Matches=this.matchRepository
                    .GetAllAttached()
                    .OrderBy(m => m.Date)
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .Include(m => m.Referee)
                    .Include(m=>m.AssistantReferee1)
                    .Include(m => m.AssistantReferee2)
                    .Where(m => m.LeagueId == league.Id && !m.IsDeleted)
                    .Select(m=> new RefereeAssignmentMatchViewModel
                    {
                        MatchId = m.Id,
                        HomeTeam = m.HomeTeam.Name,
                        HomeTeamImageUrl= m.HomeTeam.ImageUrl,
                        AwayTeam = m.AwayTeam.Name,
                        AwayTeamImageUrl = m.AwayTeam.ImageUrl,
                        Date = m.Date,
                        MainReferee = m.Referee != null ? $"{m.Referee.FirstName} {m.Referee.LastName}" : "N/A",
                        Assistant1 = m.AssistantReferee1 != null ? $"{m.AssistantReferee1.FirstName} {m.AssistantReferee1.LastName}" : "N/A",
                        Assistant2 = m.AssistantReferee2 != null ? $"{m.AssistantReferee2.FirstName} {m.AssistantReferee2.LastName}" : "N/A"
                    }).ToList();
            }
            return model;
        }
    }
}
