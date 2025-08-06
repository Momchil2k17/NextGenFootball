using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface ILeagueRepository : IRepository<League, int>, IAsyncRepository<League, int>
    {
    }
}
