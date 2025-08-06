using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.League
{
    public class LeagueStandingsViewModel
    {
        public List<TeamStandingViewModel>? Standings { get; set; }
    }

    public class TeamStandingViewModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;
        public string? TeamImageUrl { get; set; }
        public int Played { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalDifference => GoalsScored - GoalsConceded;
        public int Points { get; set; }
        public List<string>? FormLastFive { get; set; }
    }
}
