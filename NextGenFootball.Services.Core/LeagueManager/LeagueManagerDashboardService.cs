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
