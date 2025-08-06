using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class TeamStartingLineupRepository : BaseRepository<TeamStartingLineup, int>, ITeamStartingLineupRepository
    {
        public TeamStartingLineupRepository(NextGenFootballDbContext dbContext) : base(dbContext)
        {
        }
    }
}
