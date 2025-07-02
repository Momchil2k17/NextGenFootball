using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
