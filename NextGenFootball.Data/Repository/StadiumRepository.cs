using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class StadiumRepository : BaseRepository<Stadium, int>, IStadiumRepository
    {
        public StadiumRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}
