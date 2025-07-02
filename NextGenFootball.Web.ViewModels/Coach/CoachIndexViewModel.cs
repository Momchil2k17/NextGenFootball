using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class CoachIndexViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }= null!;

        public string LastName { get; set; }= null!;

        public string? ImageUrl { get; set; }

        public string TeamName { get; set; } = null!;
        public string? TeamImageUrl { get; set; }

        public string Role { get; set; } = null!;
    }
}
