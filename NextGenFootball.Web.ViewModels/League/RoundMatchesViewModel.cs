using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.League
{
    public class RoundMatchesViewModel
    {
        public int RoundNumber { get; set; }
        public List<MatchSummaryViewModel>? Matches { get; set; }
    }
}
