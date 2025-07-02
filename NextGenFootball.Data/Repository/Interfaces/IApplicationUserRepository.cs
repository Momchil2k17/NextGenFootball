using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser, Guid>, IAsyncRepository<ApplicationUser, Guid>
    {
        bool ExistsById(Guid? userId);
        Task<bool> ExistsByIdAsync(Guid? userId);
    }
}
