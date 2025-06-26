using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Season;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.LeagueValidationConstants;

namespace NextGenFootball.Web.ViewModels.League
{
    public class LeagueEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "League name must be between 3 and 100 characters.")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AgeGroupMaxLength, MinimumLength = AgeGroupMinLength, ErrorMessage = "Age group must be between 2 and 20 characters.")]
        public string AgeGroup { get; set; } = null!;

        [Required]
        public Region Region { get; set; }

        [Required]
        public int SeasonId { get; set; }

        public virtual IEnumerable<SeasonDropdownViewModel>? Seasons { get; set; }

        [StringLength(ImageUrlMaxLength, ErrorMessage = "Image URL must not exceed 2048 characters.")]
        public string? ImageUrl { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }
    }
}
