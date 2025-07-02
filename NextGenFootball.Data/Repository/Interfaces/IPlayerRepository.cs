using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IPlayerRepository : IRepository<Player, int>, IAsyncRepository<Player, int>
    {
    }
}
