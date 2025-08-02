using NextGenFootball.Web.ViewModels.League;
using NextGenFootball.Web.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Home
{
    public class HomePageViewModel
    {
        public IEnumerable<NewsIndexViewModel>? LatestNews { get; set; }
        public LeagueStandingsViewModel? Standings { get; set; }
        public LeagueUpcomingMatchesViewModel? UpcomingMatches { get; set; }
    }
}
