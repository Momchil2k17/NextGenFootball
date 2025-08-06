using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;

namespace NextGenFootball.Web.Areas.CoachManagement.Controllers
{

    public class MatchUpController : BaseCoachController
    {
        private readonly ICoachService coachService;
        private readonly ILeagueService leagueService;
        public MatchUpController(ICoachService coachService, ILeagueService leagueService)
        {
            this.coachService = coachService;
            this.leagueService = leagueService;
        }
        [HttpGet]
        public async Task<IActionResult> Upcoming()
        {
            Guid? applicationUserId = this.GetUserId();

            if (applicationUserId == null)
            { 
                return View("BadRequest", "No UserId provided"); 
            }

            var coach = await coachService.GetCoachByApplicationUserId(applicationUserId.Value);
            if (coach == null)
            {
                return View("BadRequest", "No coach found for this user.");
            }

            var teamId = await coachService.GetCoachTeamId(applicationUserId.Value);
            var league= await coachService.GetCoachLeague(applicationUserId.Value);

            if (teamId == 0 || league == null)
            {
                return View("BadRequest","Team or league information is not available.");
            }
            var matches = await leagueService.GetUpcomingMatchesForTeamAsync(league,teamId);
            if (matches == null)
            {
                return NotFound();
            }
            return View(matches);
        }
    }
}
