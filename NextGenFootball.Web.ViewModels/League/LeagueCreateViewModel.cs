using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Season;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.LeagueValidationConstants;
using static NextGenFootball.Data.Common.EntityConstants.LeagueValidationMessages;

namespace NextGenFootball.Web.ViewModels.League
{
    public class LeagueCreateViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = AgeGroupRequired)]
        [StringLength(AgeGroupMaxLength, MinimumLength = AgeGroupMinLength, ErrorMessage = AgeGroupLength)]
        public string AgeGroup { get; set; } = null!;

        [Required(ErrorMessage = RegionRequired)]
        public Region Region { get; set; }

        [Required(ErrorMessage = SeasonIdRequired)]
        public int SeasonId { get; set; }

        public virtual IEnumerable<SeasonDropdownViewModel>? Seasons { get; set; }

        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlLength)]
        public string? ImageUrl { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = DescriptionLength)]
        public string? Description { get; set; }
    }
}
