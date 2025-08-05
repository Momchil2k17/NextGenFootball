using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class LineupViewModel
    {
        public string FormationName { get; set; }=null!;
        public List<LineupPlayerViewModel> Players { get; set; } = new();
    }

    public class LineupPlayerViewModel
    {
        public string PlayerName { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
    public class FormationPositionViewModel
    {
        public string PositionName { get; set; }=null!;
        public string DisplayLabel { get; set; } = null!;
        public double X { get; set; } // percentage (e.g., 50)
        public double Y { get; set; } // percentage (e.g., 80)
    }
}
