using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class FormationPositionViewModel
    {
        public string PositionName { get; set; } = null!;
        public string DisplayLabel { get; set; } = null!;
        public double X { get; set; }
        public double Y { get; set; }
    }
}
