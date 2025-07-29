using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Match
{
    public class MatchEventViewModel
    {
        public int Minute { get; set; }
        public string PlayerName { get; set; }=null!;
        public string PlayerImageUrl { get; set; } = null!;
        public string Team { get; set; } = null!; 
        public string StatType { get; set; }=null!;
    }
}
