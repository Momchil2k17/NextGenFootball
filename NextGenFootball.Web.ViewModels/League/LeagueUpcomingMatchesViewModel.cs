using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.League
{
    public class LeagueUpcomingMatchesViewModel
    {
        public int LeagueId { get; set; }
        public List<RoundMatchesViewModel>? Rounds { get; set; }
    }
}
