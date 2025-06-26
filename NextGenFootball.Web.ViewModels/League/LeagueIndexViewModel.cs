using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.League
{
    public class LeagueIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public string Region { get; set; } = null!;
        public string AgeGroup { get; set; } = null!;
        public string SeasonName { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
