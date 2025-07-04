using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.CoachValidationConstants;
using static NextGenFootball.Data.Common.EntityConstants.CoachValidationMessages;

namespace NextGenFootball.Web.ViewModels.Coach
{
    public class CoachCreateViewModel
    {
        [Required(ErrorMessage = FirstNameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLength)]
        public string LastName { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlLength)]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = TeamRequired)]
        public int TeamId { get; set; }
        public IEnumerable<TeamDropdownViewModel>? Teams { get; set; }

        [Required(ErrorMessage = RoleRequired)]
        public CoachRole Role { get; set; }
    }
}

