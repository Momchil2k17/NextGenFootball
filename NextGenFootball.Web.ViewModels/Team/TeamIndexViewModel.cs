using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Team
{
    public class TeamIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }=null!;
        public string Region { get; set; }=null!;
        public string Stadium { get; set; }=null!;
        public string League { get; set; }=null!;
        public string? ImageUrl { get; set; } = null!;
    }
}
