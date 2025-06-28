using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Team
{
    public class TeamDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Stadium { get; set; } = null!;
        public string League { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

        // Uncomment and implement PlayerViewModel when ready
        // public IEnumerable<PlayerViewModel> Players { get; set; }
    }
}
