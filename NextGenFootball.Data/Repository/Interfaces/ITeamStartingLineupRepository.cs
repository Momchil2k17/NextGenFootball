using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface ITeamStartingLineupRepository : IRepository<TeamStartingLineup, int>, IAsyncRepository<TeamStartingLineup, int>
    {
    }
}
