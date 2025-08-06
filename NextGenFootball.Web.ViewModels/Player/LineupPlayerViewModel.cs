using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class LineupPlayerViewModel
    {
        public string PlayerName { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
