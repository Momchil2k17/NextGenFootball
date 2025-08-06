using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IPlayerRepository : IRepository<Player, Guid>, IAsyncRepository<Player, Guid>
    {
    }
}
