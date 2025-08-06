using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class SeasonRepository : BaseRepository<Season, int>, ISeasonRepository
    {
        public SeasonRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
