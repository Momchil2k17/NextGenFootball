using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Match
{
    public class MatchIndexViewModel
    {
            public long Id { get; set; }
            public int HomeTeamId { get; set; }
            public string HomeTeamName { get; set; } = null!;
            public string? HomeTeamImageUrl { get; set; } = null!;
            public int AwayTeamId { get; set; }
            public string AwayTeamName { get; set; } = null!;
            public string? AwayTeamImageUrl { get; set; } = null!;
            public int? HomeScore { get; set; }
            public int? AwayScore { get; set; }
            public DateTime Date { get; set; }
            public string StadiumName { get; set; } = null!;
            public MatchStatus Status { get; set; }
            public bool IsPlayed { get; set; }
    }
}
