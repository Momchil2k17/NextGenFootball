using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Referee.RefereeMatches
{
    public class MyMatchesViewModel
    {
        public long MatchId { get; set; }
        public DateTime Date { get; set; }
        public string HomeTeamName { get; set; }=null!;
        public string? HomeTeamImageUrl { get; set; } 
        public string AwayTeamName { get; set; } = null!;
        public string? AwayTeamImageUrl { get; set; }
        public string StadiumName { get; set; } = null!;
        public string LeagueName { get; set; }  = null!;
        public string? RefereeName { get; set; }
        public string? AssistantReferee1Name { get; set; }
        public string? AssistantReferee2Name { get; set; }
        public MatchStatus Status { get; set; }
        public string MyRole { get; set; }=null!; // "Main Referee", "Assistant Referee 1", "Assistant Referee 2"
    }
}
