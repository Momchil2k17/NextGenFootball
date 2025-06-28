using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerForTeamDetailsViewModel
    {
        public string Name { get; set; }=null!;
        public string Position { get; set; }=null!;
        public string? ImageUrl { get; set; }
    }
}
