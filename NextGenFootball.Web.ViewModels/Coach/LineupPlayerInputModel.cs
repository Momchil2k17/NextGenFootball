using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class LineupPlayerInputModel
    {
        public Guid PlayerId { get; set; }
        public string PositionName { get; set; } = null!;
        public int PositionNumber { get; set; }
    }
}
