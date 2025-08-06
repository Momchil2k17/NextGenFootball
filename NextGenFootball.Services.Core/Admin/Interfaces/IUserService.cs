using NextGenFootball.Web.ViewModels.Admin.UserManagement;

namespace NextGenFootball.Services.Core.Admin.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserManagementIndexViewModel>> GetUserManagementBoardDataAsync(Guid userId);
        Task<bool> AssignUserToRoleAsync(RoleSelectionInputModel inputModel);
        Task<bool> RemoveUserFromRoleAsync(RoleSelectionInputModel inputModel);
    }
}
