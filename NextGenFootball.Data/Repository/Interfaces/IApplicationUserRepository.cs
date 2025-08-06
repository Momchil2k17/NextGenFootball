using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser, Guid>, IAsyncRepository<ApplicationUser, Guid>
    {
        bool ExistsById(Guid? userId);
        Task<bool> ExistsByIdAsync(Guid? userId);
    }
}
