using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class MatchEventRepository : BaseRepository<MatchEvent, int>, IMatchEventRepository
    {
        public MatchEventRepository(NextGenFootballDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
