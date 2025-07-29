using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    public class MatchReport
    {
        [Key]
        public Guid Id { get; set; }
        public long MatchId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public virtual Match? Match { get; set; }
        public virtual ICollection<MatchEvent> Events { get; set; } = new HashSet<MatchEvent>();
    }
}
