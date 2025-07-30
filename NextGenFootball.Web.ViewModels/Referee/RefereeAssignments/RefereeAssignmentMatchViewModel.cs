using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Referee.RefereeAssignments
{
    public class RefereeAssignmentMatchViewModel
    {
        public long MatchId { get; set; }
        public string HomeTeam { get; set; }=null!;
        public string AwayTeam { get; set; } = null!;
        public string? HomeTeamImageUrl { get; set; }
        public string? AwayTeamImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string? MainReferee { get; set; }
        public string? Assistant1 { get; set; }
        public string? Assistant2 { get; set; }
    }
}
