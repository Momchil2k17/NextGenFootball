using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Stadium
{
    public class StadiumIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Address { get; set; } = null!;
        public int Capacity { get; set; }
        public string Surface { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
