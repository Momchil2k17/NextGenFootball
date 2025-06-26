using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Season;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.League
{
    public class LeagueCreateViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "League name must be between 3 and 100 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Age group must be between 2 and 20 characters.")]
        public string AgeGroup { get; set; } = null!;

        [Required]
        public Region Region { get; set; } 

        [Required]
        public int SeasonId { get; set; }
        
        public virtual IEnumerable<SeasonDropdownViewModel>? Seasons { get; set; }

        [StringLength(2048, ErrorMessage = "Image URL must not exceed 2048 characters.")]
        public string? ImageUrl { get; set; }

        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }
    }
}
