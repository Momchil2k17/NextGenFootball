using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class TeamStartingLineupPlayerRepository : BaseRepository<TeamStartingLineupPlayer, int>, ITeamStartingLineupPlayerRepository
    {
        public TeamStartingLineupPlayerRepository(NextGenFootballDbContext dbContext) : base(dbContext)
        {
        }
    }
}
