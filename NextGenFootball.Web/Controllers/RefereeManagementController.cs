using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.RefereeManagement;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Controllers
{
    [Authorize(Roles = AdminRoleName)]
    public class RefereeManagementController : BaseController
    {
        private readonly IRefereeService refereeService;
        public RefereeManagementController(IRefereeService refereeService)
        {
            this.refereeService = refereeService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<RefereeIndexViewModel>? referees = await this.refereeService.GetAllRefereesAsync();
            return View(referees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RefereeCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool res = await this.refereeService.CreateRefereeAsync(model);
            if (!res)
            {
                ModelState.AddModelError("", "Failed to create referee.");
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            RefereeEditViewModel? model = await this.refereeService.GetRefereeByForEdit(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RefereeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool res = await this.refereeService.EditRefereeAsync(model);
            if (!res)
            {
                ModelState.AddModelError("", "Failed to edit referee.");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
