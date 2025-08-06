using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Repository.Interfaces
{
    public interface IMatchReportRepository: IRepository<MatchReport, Guid>, IAsyncRepository<MatchReport, Guid>
    {
    }
}
