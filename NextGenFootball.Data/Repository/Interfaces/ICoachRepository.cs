using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface ICoachRepository : IRepository<Coach,Guid>,IAsyncRepository<Coach,Guid>
    {
    }
}
