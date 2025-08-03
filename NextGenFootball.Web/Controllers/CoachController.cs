using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;

namespace NextGenFootball.Web.Controllers
{
    [Authorize]
    public class CoachController : BaseController
    {
        private readonly ICoachService coachService;
        private readonly ITeamService teamService;
        public CoachController(ICoachService coachService, ITeamService teamService)
        {
            this.coachService = coachService;
            this.teamService = teamService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CoachIndexViewModel> coaches = await this.coachService.GetAllCoachesAsync();
            return View(coaches);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid? id)
        {
            CoachDetailsViewModel? details = await this.coachService.GetCoachDetailsAsync(id);
            if (details == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(details);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CoachCreateViewModel model = new CoachCreateViewModel
            {
                Teams = await this.teamService.GetTeamDropdownViewModelsAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CoachCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                return View(model);
            }
            bool isCreated = await this.coachService.CreateCoachAsync(model);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Coach creation failed. Please try again.");
                model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            CoachEditViewModel? model = await this.coachService.GetCoachEditViewModel(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CoachEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                return View(model);
            }
            bool isEdited = await this.coachService.EditCoachAsync(model);
            if (!isEdited)
            {
                ModelState.AddModelError(string.Empty, "Coach edit failed. Please try again.");
                model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            CoachDeleteViewModel? model = await this.coachService.GetCoachForDeleteAsync(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CoachDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isDeleted = await this.coachService.DeleteCoachAsync(model);
            if (!isDeleted)
            {
                ModelState.AddModelError(string.Empty, "Coach deletion failed. Please try again.");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
