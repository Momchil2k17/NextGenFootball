using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class NewsRepository : BaseRepository<News, int>, INewsRepository
    {
        public NewsRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
