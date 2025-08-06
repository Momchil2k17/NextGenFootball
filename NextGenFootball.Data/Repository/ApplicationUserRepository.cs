using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser, Guid>, IApplicationUserRepository
    {
        public ApplicationUserRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        {
            
        }

        public bool ExistsById(Guid? userId)
        {
            return this.DbContext.Users.Any(u => u.Id == userId);
        }

        public Task<bool> ExistsByIdAsync(Guid? userId)
        {
            return this.DbContext.Users.AnyAsync(u => u.Id == userId);
        }
    }
}
