using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface INewsRepository : IRepository<News, int>, IAsyncRepository<News, int>
    {
    }
}
