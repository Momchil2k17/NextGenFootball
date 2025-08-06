using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface ITeamStartingLineupPlayerRepository : IRepository<TeamStartingLineupPlayer, int>, IAsyncRepository<TeamStartingLineupPlayer, int>
    {
    }
}
