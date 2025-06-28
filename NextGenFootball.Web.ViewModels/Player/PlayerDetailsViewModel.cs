using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerDetailsViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }= null!;
        public string LastName { get; set; }= null!;

        public string TeamName { get; set; } = null!;
        public string TeamImageUrl { get; set; } = null!;

        public string PreferredFoot { get; set; } = null!;
        public DateTime DateOfBirth { get; set; } 
        public string? ImageUrl { get; set; }

        // Statistics
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
    }
}
