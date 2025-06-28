using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Team;

namespace NextGenFootball.Web.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ITeamService teamService;
        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<TeamIndexViewModel> teams = await this.teamService.GetAllTeamsAsync();
            return View(teams);
        }
    }
}
