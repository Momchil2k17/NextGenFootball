using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IStadiumRepository: IRepository<Stadium, int>, IAsyncRepository<Stadium, int>
    {
    }
}
