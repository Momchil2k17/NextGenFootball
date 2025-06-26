using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;

namespace NextGenFootball.Web.Controllers
{
    public class LeagueController : BaseController
    {
        private readonly ILeagueService leagueService;
        public LeagueController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<LeagueIndexViewModel> leagues = await this.leagueService.GetAllLeaguesAsync();
            return View(leagues);
        }
    }
}
