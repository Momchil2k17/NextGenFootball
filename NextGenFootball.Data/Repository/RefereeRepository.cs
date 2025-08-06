using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class RefereeRepository : BaseRepository<Referee, Guid>, IRefereeRepository
    {
        public RefereeRepository(NextGenFootballDbContext dbContext) : base(dbContext)
        {
        }
    }
}
