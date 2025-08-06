using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class MatchRepository : BaseRepository<Match,long>, IMatchRepository
    {
        public MatchRepository(NextGenFootballDbContext dbContext)
           : base(dbContext)
        {

        }
    }
}
