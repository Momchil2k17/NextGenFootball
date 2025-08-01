using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Services.Core.LeagueManager.Interfaces;
using NextGenFootball.Web.ViewModels.Match;
using NextGenFootball.Web.ViewModels.Referee.RefereeAssignments;

namespace NextGenFootball.Web.Areas.LeagueManager.Controllers
{
    public class DashboardController : BaseLeagueManagerController
    {
        private readonly ILeagueService leagueService;
        private readonly ISeasonService seasonService;
        private readonly IMatchService matchService;
        private readonly ITeamService teamService;
        private readonly ILeagueManagerDashboardService leagueManagerDashboardService;
        public DashboardController(ILeagueService leagueService, ISeasonService seasonService
            , IMatchService matchService, ITeamService teamService, ILeagueManagerDashboardService leagueManagerDashboardService)
        {
            this.leagueService = leagueService;
            this.seasonService = seasonService;
            this.matchService = matchService;
            this.teamService = teamService;
            this.leagueManagerDashboardService = leagueManagerDashboardService;
        }
        public IActionResult Index(int id)
        {
            ViewBag.LeagueId = id;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateMatch(int id)
        {
            MatchCreateViewModel matchCreateViewModel = new MatchCreateViewModel
            {
                Teams = await this.teamService.GetTeamDropdownViewModelsByLeagueAsync(id),
                Date = this.leagueService.GetNearestQuarter(DateTime.Now),
                LeagueId = id,
            };
            return View(matchCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMatch(MatchCreateViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Teams = await this.teamService.GetTeamDropdownViewModelsByLeagueAsync(id);
                return View(model);
            }
            bool isCreated = await this.matchService.CreateMatchAsync(model, id);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Match creation failed. Please try again.");
                model.Teams = await this.teamService.GetTeamDropdownViewModelsByLeagueAsync(id);
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Assignments(int id)
        {
            var model = await this.leagueManagerDashboardService.GetMatchesForAssignment(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AssignReferee(long matchId, int leagueId)
        {
            var model = await this.leagueManagerDashboardService.GetMatchDetailsForAssignment(matchId, leagueId);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignReferee(AssignRefereeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isAssigned = await this.leagueManagerDashboardService.AssignRefereeToMatchAsync(model);
            if (!isAssigned)
            {
                ModelState.AddModelError(string.Empty, "Failed to assign referees. Please try again.");
                return View(model);
            }
            return RedirectToAction(nameof(Assignments), new { id = model.LeagueId });
        }
    }
}
