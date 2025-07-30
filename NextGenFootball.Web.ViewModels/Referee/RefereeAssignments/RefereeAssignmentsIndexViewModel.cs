using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Referee.RefereeAssignments
{
    public class RefereeAssignmentsIndexViewModel
    {
        public int LeagueId { get; set; }
        public List<RefereeAssignmentMatchViewModel>? Matches { get; set; }
    }
}
