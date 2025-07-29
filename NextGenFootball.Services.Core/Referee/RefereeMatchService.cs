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
        private readonly UserManager<ApplicationUser> userManager;  
        public RefereeMatchService(IMatchRepository matchRepository,UserManager<ApplicationUser> userManager
            ,IRefereeRepository refereeRepository)
        {
            this.matchRepository = matchRepository;
            this.userManager = userManager;
            this.refereeRepository = refereeRepository;
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
                            m.AssistantReferee1!.ApplicationUserId == id ? "Assistant Referee 1" :
                            m.AssistantReferee2!.ApplicationUserId == id ? "Assistant Referee 2" : "Unknown",
                    Status=m.Status,
                });
            return matches;
        }
    }
}
