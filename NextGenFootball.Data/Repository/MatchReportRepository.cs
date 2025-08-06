using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class MatchReportRepository : BaseRepository<MatchReport, Guid>, IMatchReportRepository
    {
        public MatchReportRepository(NextGenFootballDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
