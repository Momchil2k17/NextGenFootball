using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;

namespace NextGenFootball.Web.Areas.LeagueManager.Controllers
{
    public class HomeController : BaseLeagueManagerController
    {
        private readonly ILeagueService leagueService;
        private readonly ISeasonService seasonService;
        private readonly IMatchService matchService;
        private readonly ITeamService teamService;
        public HomeController(ILeagueService leagueService, ISeasonService seasonService
            , IMatchService matchService, ITeamService teamService)
        {
            this.leagueService = leagueService;
            this.seasonService = seasonService;
            this.matchService = matchService;
            this.teamService = teamService;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<LeagueIndexViewModel> leagues = await this.leagueService.GetAllLeaguesAsync();
            return View(leagues);
        }
    }
}
