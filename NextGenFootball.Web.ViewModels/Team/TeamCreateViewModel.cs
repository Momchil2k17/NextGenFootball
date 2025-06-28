using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.League;
using NextGenFootball.Web.ViewModels.Stadium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.TeamValidationConstants;

namespace NextGenFootball.Web.ViewModels.Team
{
    public class TeamCreateViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Team name must be between 3 and 100 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AgeGroupMaxLength, MinimumLength = AgeGroupMinLength, ErrorMessage = "Age group must be between 2 and 20 characters.")]
        public string AgeGroup { get; set; } = null!;

        [Required]
        public Region Region { get; set; }

        [Required(ErrorMessage = "League is required.")]
        public int LeagueId { get; set; }
        public virtual IEnumerable<LeagueDropdownViewModel>? Leagues { get; set; }

        [Required(ErrorMessage = "Stadium is required.")]
        public int StadiumId { get; set; }
        public virtual IEnumerable<StadiumDropdownViewModel>? Stadiums { get; set; }

        [StringLength(ImageUrlMaxLength, ErrorMessage = "Image URL must not exceed 2048 characters.")]
        public string? ImageUrl { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }


    }
}
