using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class CoachRepository : BaseRepository<Coach, Guid>, ICoachRepository
    {
        public CoachRepository(NextGenFootballDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
