using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Stadium;
using NextGenFootball.Web.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Match
{
    public class MatchCreateViewModel
    {
        public int LeagueId { get; set; }

        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int AwayTeamId { get; set; }
        public IEnumerable<TeamDropdownViewModel>? Teams { get; set; }


        [Required]
        public DateTime Date { get; set; }

    }
}
