using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IRefereeRepository : IRepository<Referee, Guid>, IAsyncRepository<Referee, Guid>
    {
    }
}
