using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class TeamRepository : BaseRepository<Team, int>, ITeamRepository
    {
        public TeamRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
