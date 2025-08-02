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

    public class RoundMatchesViewModel
    {
        public int RoundNumber { get; set; }
        public List<MatchSummaryViewModel>? Matches { get; set; }
    }

    public class MatchSummaryViewModel
    {
        public long MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeam { get; set; } = null!;
        public string? HomeTeamImageUrl { get; set; }
        public int AwayTeamId { get; set; }
        public string AwayTeam { get; set; } = null!;
        public string? AwayTeamImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
