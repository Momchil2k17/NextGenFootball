using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Referee.RefereeMatches
{
    public class PlayerSimpleDto
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public string? PlayerImageUrl { get; set; }
    }
}
