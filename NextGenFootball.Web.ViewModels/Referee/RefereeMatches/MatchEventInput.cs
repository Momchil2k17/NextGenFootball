using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Referee.RefereeMatches
{
    public class MatchEventInput
    {
        public int Minute { get; set; }
        public Guid PlayerId { get; set; }
        public string StatType { get; set; } = null!;
    }
}
