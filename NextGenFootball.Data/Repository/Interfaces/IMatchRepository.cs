using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IMatchRepository : IRepository<Match,long> , IAsyncRepository<Match,long>
    {
    }
}
