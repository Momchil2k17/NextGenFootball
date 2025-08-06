using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Match
{
    public class MatchDetailsViewModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int StadiumId { get; set; }
        public string StadiumName { get; set; }= null!;
        public string HomeTeamName { get; set; } = null!;
        public string? HomeTeamImageUrl { get; set; }
        public int? HomeScore { get; set; }
        public string AwayTeamName { get; set; }= null!;
        public string? AwayTeamImageUrl { get; set; }
        public int? AwayScore { get; set; }
        public bool IsPlayed { get; set; }
        public string LeagueName { get; set; } = null!;
        public string? VideoUrl { get; set; }
        public LineupViewModel? HomeTeamLineup { get; set; }
        public LineupViewModel? AwayTeamLineup { get; set; }
        public List<MatchEventViewModel> Events { get; set; } = new List<MatchEventViewModel>();
    }
}
