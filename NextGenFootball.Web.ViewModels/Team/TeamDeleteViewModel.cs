using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Team
{
    public class TeamDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string AgeGroup { get; set; } = null!;
        public string LeagueName { get; set; } = null!;
    }
}
