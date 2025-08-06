using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IMatchEventRepository : IRepository<MatchEvent, int>, IAsyncRepository<MatchEvent, int>
    {
    }
}
