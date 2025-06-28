using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerIndexViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }=null!;
        public string LastName { get; set; } = null!;

        public string TeamName { get; set; } = null!;
        public string SeasonName { get; set; } = null!;

        public string PreferredFoot { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? ImageUrl { get; set; }
        public string? TeamImageUrl { get; set; }
    }
}
