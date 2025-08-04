using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Admin.Interfaces;
using NextGenFootball.Web.ViewModels.Admin.UserManagement;

namespace NextGenFootball.Web.Areas.Admin.Controllers
{
    public class UserManagementController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            Guid? userId = this.GetUserId();
            if (userId == null)
            {
                return BadRequest("User ID is not available.");
            }
            IEnumerable<UserManagementIndexViewModel> allUsers = await this.userService
                .GetUserManagementBoardDataAsync(userId.Value);

            return View(allUsers);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleSelectionInputModel inputModel)
        {
            try
            {
                await this.userService
                    .AssignUserToRoleAsync(inputModel);

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRole(RoleSelectionInputModel inputModel)
        {
            try
            {
                await this.userService
                    .RemoveUserFromRoleAsync(inputModel);
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
