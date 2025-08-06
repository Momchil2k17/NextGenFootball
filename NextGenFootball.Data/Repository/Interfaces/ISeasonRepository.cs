using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface ISeasonRepository : IRepository<Season, int>, IAsyncRepository<Season, int>
    {
    }
}
