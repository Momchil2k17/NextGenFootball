using NextGenFootball.Web.ViewModels.Referee.RefereeAssignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.LeagueManager.Interfaces
{
    public interface ILeagueManagerDashboardService
    {
        public Task<RefereeAssignmentsIndexViewModel> GetMatchesForAssignment(int id);
    }
}
