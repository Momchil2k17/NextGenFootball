using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Season;

namespace NextGenFootball.Web.Controllers
{
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
        public async Task<IActionResult> Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SeasonCreateViewModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(inputModel);
                }
                string userId = this.GetUserId()!;
                bool isCreated = await this.seasonService.CreateSeasonAsync(inputModel, userId);
                if (isCreated == false)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the season. Please try again.");
                    return RedirectToAction(nameof(Create));
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
                SeasonDetailsViewModel? season = await this.seasonService.GetSeasonDetailsAsync(id);
                if (season == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(season);
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
                SeasonEditViewModel? season = await this.seasonService.GetSeasonForEditAsync(id, userId);
                if (season == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(season);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SeasonEditViewModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(inputModel);
                }
                string userId = this.GetUserId()!;
                bool isEdited = await this.seasonService.EditSeasonAsync(inputModel, userId);
                if (isEdited == false)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while editing the season. Please try again.");
                    return RedirectToAction(nameof(Edit), new { id = inputModel.Id });
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
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;
                SeasonDeleteViewModel? season = await this.seasonService.GetSeasonForDeleteAsync(id, userId);
                if (season == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(season);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SeasonDeleteViewModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(inputModel);
                }
                string userId = this.GetUserId()!;
                bool isDeleted = await this.seasonService.DeleteSeasonAsync(inputModel, userId);
                if (isDeleted == false)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while deleting the season. Please try again.");
                    return RedirectToAction(nameof(Delete), new { id = inputModel.Id });
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
