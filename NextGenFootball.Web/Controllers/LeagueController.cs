using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;
using NextGenFootball.Web.ViewModels.Season;

namespace NextGenFootball.Web.Controllers
{
    public class LeagueController : BaseController
    {
        private readonly ILeagueService leagueService;
        private readonly ISeasonService seasonService;
        public LeagueController(ILeagueService leagueService, ISeasonService seasonService)
        {
            this.leagueService = leagueService;
            this.seasonService = seasonService;
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
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                    return View(model);
                }
                string userId = this.GetUserId()!;
                bool isCreated = await this.leagueService.CreateLeagueAsync(model, userId);
                if (!isCreated)
                {
                    ModelState.AddModelError(string.Empty, "League creation failed. Please try again.");
                    model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                    return View(model);
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                LeagueDetailsViewModel? league = await this.leagueService.GetLeagueDetailsAsync(id);
                if (league == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(league);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;
                LeagueEditViewModel? league = await this.leagueService.GetLeagueForEditAsync(id, userId);
                if (league == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                league.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(league);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LeagueEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                    return View(model);
                }
                string userId = this.GetUserId()!;
                bool isEdited = await this.leagueService.EditLeagueAsync(model, userId);
                if (!isEdited)
                {
                    ModelState.AddModelError(string.Empty, "League edit failed. Please try again.");
                    model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
