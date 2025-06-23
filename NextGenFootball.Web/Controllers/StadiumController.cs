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
        public async Task<IActionResult> Create()
        {
            return this.View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StadiumCreateViewModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(inputModel);
                }
                string userId = this.GetUserId()!;
                bool isCreated = await this.stadiumService.CreateStadiumAsync(inputModel, userId);
                if (isCreated == false)
                {
                    //TODO: add validation messages class
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the stadium. Please try again.");
                    return View(inputModel);
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //TODO: add validation messages class
                ModelState.AddModelError(string.Empty, "An error occurred while creating the stadium. Please try again.");
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                StadiumDetailsViewModel? stadium = await this.stadiumService.GetStadiumDetailsAsync(id);
                if (stadium == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(stadium);
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
                StadiumEditViewModel? stadium = await this.stadiumService.GetStadiumForEditAsync(id, userId);
                if (stadium == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(stadium);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));

            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StadiumEditViewModel stadium)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(stadium);
                }
                string userId = this.GetUserId()!;
                bool isEdited = await this.stadiumService.EditStadiumAsync(stadium, userId);
                if (!isEdited)
                {
                    this.ModelState.AddModelError(string.Empty, "An error occurred while editing the stadium. Please try again.");
                    return View(stadium);
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
                StadiumDeleteViewModel? stadium = await this.stadiumService.GetStadiumForDeleteAsync(id, userId);
                if (stadium == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(stadium);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(StadiumDeleteViewModel stadium)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View(stadium);
                }
                string userId = this.GetUserId()!;
                bool isDeleted = await this.stadiumService.DeleteStadiumAsync(stadium, userId);
                if (!isDeleted)
                {
                    this.ModelState.AddModelError(string.Empty, "An error occurred while deleting the stadium. Please try again.");
                    return View(stadium);
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
