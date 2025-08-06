using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Match
{
    public class AddVideoToMatchViewModel
    {
        public long Id { get; set; }
        public string VideoUrl { get; set; } = null!;
    }
}
