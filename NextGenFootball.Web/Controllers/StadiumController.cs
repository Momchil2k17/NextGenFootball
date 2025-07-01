using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Stadium;

namespace NextGenFootball.Web.Controllers
{
    public class StadiumController : BaseController
    {
        private readonly IStadiumService stadiumService;
        public StadiumController(IStadiumService stadiumService)
        {
            this.stadiumService = stadiumService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<StadiumIndexViewModel> stadiums = await this.stadiumService.GetAllStadiumsAsync();
            return View(stadiums);
        }
        [HttpGet]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IActionResult> Create()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StadiumCreateViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            bool isCreated = await this.stadiumService.CreateStadiumAsync(inputModel);
            if (isCreated == false)
            {
                //TODO: add validation messages class
                ModelState.AddModelError(string.Empty, "An error occurred while creating the stadium. Please try again.");
                return View(inputModel);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            StadiumDetailsViewModel? stadium = await this.stadiumService.GetStadiumDetailsAsync(id);
            if (stadium == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(stadium);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            StadiumEditViewModel? stadium = await this.stadiumService.GetStadiumForEditAsync(id);
            if (stadium == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(stadium);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StadiumEditViewModel stadium)
        {
            if (!this.ModelState.IsValid)
            {
                return View(stadium);
            }
            bool isEdited = await this.stadiumService.EditStadiumAsync(stadium);
            if (!isEdited)
            {
                this.ModelState.AddModelError(string.Empty, "An error occurred while editing the stadium. Please try again.");
                return View(stadium);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            string userId = this.GetUserId()!;
            StadiumDeleteViewModel? stadium = await this.stadiumService.GetStadiumForDeleteAsync(id);
            if (stadium == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(stadium);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(StadiumDeleteViewModel stadium)
        {
            if (!this.ModelState.IsValid)
            {
                return View(stadium);
            }
            bool isDeleted = await this.stadiumService.DeleteStadiumAsync(stadium);
            if (!isDeleted)
            {
                this.ModelState.AddModelError(string.Empty, "An error occurred while deleting the stadium. Please try again.");
                return View(stadium);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
