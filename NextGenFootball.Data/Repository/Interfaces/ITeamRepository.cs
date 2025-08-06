using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface ITeamRepository : IRepository<Team, int>, IAsyncRepository<Team, int>
    {
    }
}
