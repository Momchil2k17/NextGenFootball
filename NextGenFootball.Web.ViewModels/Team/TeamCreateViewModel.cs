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
using static NextGenFootball.Data.Common.EntityConstants.TeamValidationMessages;

namespace NextGenFootball.Web.ViewModels.Team
{
    public class TeamCreateViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = AgeGroupRequired)]
        [StringLength(AgeGroupMaxLength, MinimumLength = AgeGroupMinLength, ErrorMessage = AgeGroupLength)]
        public string AgeGroup { get; set; } = null!;

        [Required(ErrorMessage = RegionRequired)]
        public Region Region { get; set; }

        [Required(ErrorMessage = LeagueRequired)]
        public int LeagueId { get; set; }
        public virtual IEnumerable<LeagueDropdownViewModel>? Leagues { get; set; }

        [Required(ErrorMessage = StadiumRequired)]
        public int StadiumId { get; set; }
        public virtual IEnumerable<StadiumDropdownViewModel>? Stadiums { get; set; }

        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlLength)]
        public string? ImageUrl { get; set; }

        [StringLength(DescriptionMaxLength, ErrorMessage = DescriptionLength)]
        public string? Description { get; set; }
    }
}
