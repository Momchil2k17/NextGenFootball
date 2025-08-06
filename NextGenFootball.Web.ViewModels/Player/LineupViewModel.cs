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
   
}
