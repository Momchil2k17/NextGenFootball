using NextGenFootball.Web.ViewModels.Referee.RefereeMatches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Referee.Interfaces
{
    public interface IRefereeMatchService
    {
        public Task<IEnumerable<MyMatchesViewModel?>> GetRefereeMatches(Guid? id);
        public Task<MatchReportViewModel?> GetMatchReportView(long matchId);
        public Task CreateMatchReportAsync(MatchReportViewModel matchReport);
    }
}
