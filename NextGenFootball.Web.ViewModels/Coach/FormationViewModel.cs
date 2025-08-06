using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class FormationViewModel
    {
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public List<FormationPosition> Positions { get; set; } = new();
    }
}
