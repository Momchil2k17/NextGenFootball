using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Referee.RefereeMatches
{
    public class MatchReportViewModel
    {
        public long MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string RefereeName { get; set; } = null!;  
        public List<PlayerSimpleDto> HomePlayers { get; set; } = new List<PlayerSimpleDto>();
        public List<PlayerSimpleDto> AwayPlayers { get; set; } = new List<PlayerSimpleDto>();

        public List<MatchEventInput> FirstHalfHomeEvents { get; set; }=new List<MatchEventInput>();
        public List<MatchEventInput> FirstHalfAwayEvents { get; set; } = new List<MatchEventInput>();
        public List<MatchEventInput> SecondHalfHomeEvents { get; set; } = new List<MatchEventInput>();
        public List<MatchEventInput> SecondHalfAwayEvents { get; set; }  = new List<MatchEventInput>();
    }
}
