using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class FormationPosition
    {
        public string PositionName { get; set; } = null!;
        public string DisplayLabel { get; set; } = null!;
        public int X { get; set; }
        public int Y { get; set; }
    }
}
