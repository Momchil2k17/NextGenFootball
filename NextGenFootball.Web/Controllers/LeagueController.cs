using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;
using NextGenFootball.Web.ViewModels.Match;
using NextGenFootball.Web.ViewModels.Season;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Controllers
{
    [Authorize(Roles = LeagueManagerRoleName+","+AdminRoleName)]
    public class LeagueController : BaseController
    {
        private readonly ILeagueService leagueService;
        private readonly ISeasonService seasonService;
        private readonly IMatchService matchService;
        private readonly ITeamService teamService;
        public LeagueController(ILeagueService leagueService, ISeasonService seasonService
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            LeagueCreateViewModel leagueCreateViewModel = new LeagueCreateViewModel
            {
                Seasons = await this.seasonService.GetSeasonsForDropdownAsync()
            };
            return View(leagueCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LeagueCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(model);
            }
            bool isCreated = await this.leagueService.CreateLeagueAsync(model);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "League creation failed. Please try again.");
                model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            LeagueDetailsViewModel? league = await this.leagueService.GetLeagueDetailsAsync(id);
            if (league == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(league);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            string userId = this.GetUserId()!;
            LeagueEditViewModel? league = await this.leagueService.GetLeagueForEditAsync(id);
            if (league == null)
            {
                return RedirectToAction(nameof(Index));
            }
            league.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
            return View(league);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LeagueEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(model);
            }
            bool isEdited = await this.leagueService.EditLeagueAsync(model);
            if (!isEdited)
            {
                ModelState.AddModelError(string.Empty, "League edit failed. Please try again.");
                model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            LeagueDetailsViewModel? league = await this.leagueService.GetLeagueForDeleteAsync(id);
            if (league == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(league);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(LeagueDetailsViewModel model)
        {
            bool isDeleted = await this.leagueService.DeleteLeagueAsync(model);
            if (!isDeleted)
            {
                ModelState.AddModelError(string.Empty, "League deletion failed. Please try again.");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CreateMatch(int? id)
        {
            MatchCreateViewModel matchCreateViewModel = new MatchCreateViewModel
            {
                Teams = await this.teamService.GetTeamDropdownViewModelsByLeagueAsync(id),
                Date= this.leagueService.GetNearestQuarter(DateTime.Now),
            };
            return View(matchCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMatch(MatchCreateViewModel model, int? id)
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
    }
}
