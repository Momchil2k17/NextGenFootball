using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;

namespace NextGenFootball.Data.Repository
{
    public class PlayerRepository : BaseRepository<Player, Guid>, IPlayerRepository
    {
        public PlayerRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        { 
        }
    }
}
