using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    public class TeamStartingLineup
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;
        public Guid CoachId { get; set; }
        public Coach Coach { get; set; } = null!;
        public string FormationName { get; set; } = null!; 
        public DateTime UpdatedOn { get; set; }
        public ICollection<TeamStartingLineupPlayer> Players { get; set; } = new List<TeamStartingLineupPlayer>();
    }
}
