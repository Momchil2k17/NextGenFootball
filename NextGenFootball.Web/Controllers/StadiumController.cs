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
                if(isCreated==false)
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
    }
}
