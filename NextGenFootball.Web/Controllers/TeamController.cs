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
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                TeamDetailsViewModel? team = await this.teamService.GetTeamDetailsAsync(id);
                if (team == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(team);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
