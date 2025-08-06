using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class LeagueRepository : BaseRepository<League, int>, ILeagueRepository
    {
        public LeagueRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
