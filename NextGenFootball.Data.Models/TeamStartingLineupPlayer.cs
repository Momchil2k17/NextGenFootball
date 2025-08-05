using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    public class TeamStartingLineupPlayer
    {
        public int Id { get; set; }
        public int TeamStartingLineupId { get; set; }
        public TeamStartingLineup TeamStartingLineup { get; set; } = null!;
        public Guid PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public string PositionName { get; set; } = null!;
        public int PositionNumber { get; set; } 
    }
}
