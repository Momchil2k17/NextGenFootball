using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class TopGoalscorerViewModel
    {
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public string? PlayerImageUrl { get; set; }
        public string TeamName { get; set; }= null!;
        public string? TeamImageUrl { get; set; }
        public int Goals { get; set; }
    }
}
