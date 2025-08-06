using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Season;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Controllers
{
    [Authorize(Roles =AdminRoleName)]
    public class SeasonController : BaseController
    {
        private readonly ISeasonService seasonService;
        public SeasonController(ISeasonService seasonService)
        {
            this.seasonService = seasonService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SeasonIndexViewModel> seasons = await this.seasonService.GetAllSeasonsAsync();
            return View(seasons);
        }
        [HttpGet]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> Create()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SeasonCreateViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            bool isCreated = await this.seasonService.CreateSeasonAsync(inputModel);
            if (isCreated == false)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the season. Please try again.");
                return RedirectToAction(nameof(Create));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            SeasonDetailsViewModel? season = await this.seasonService.GetSeasonDetailsAsync(id);
            if (season == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            SeasonEditViewModel? season = await this.seasonService.GetSeasonForEditAsync(id);
            if (season == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SeasonEditViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            bool isEdited = await this.seasonService.EditSeasonAsync(inputModel);
            if (isEdited == false)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while editing the season. Please try again.");
                return RedirectToAction(nameof(Edit), new { id = inputModel.Id });
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            SeasonDeleteViewModel? season = await this.seasonService.GetSeasonForDeleteAsync(id);
            if (season == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(season);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SeasonDeleteViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            bool isDeleted = await this.seasonService.DeleteSeasonAsync(inputModel);
            if (isDeleted == false)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the season. Please try again.");
                return RedirectToAction(nameof(Delete), new { id = inputModel.Id });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
