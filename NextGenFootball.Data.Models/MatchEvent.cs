using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    public class MatchEvent
    {
        [Key]
        public int Id { get; set; }
        public Guid MatchReportId { get; set; }
        public int Minute { get; set; }
        public Guid PlayerId { get; set; }
        public string StatType { get; set; } = null!;
        public int Half { get; set; } 
        public string Team { get; set; } = null!; 

        public virtual MatchReport? MatchReport { get; set; }
    }
}
