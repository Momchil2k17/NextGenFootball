using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Web.ViewModels.Season;
using NextGenFootball.Web.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.PlayerValidationConstants;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerCreateViewModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(PositionMaxLength, MinimumLength = PositionMinLength)]
        public string Position { get; set; } = null!;

        [Required]
        public PreferredFoot PreferredFoot { get; set; }

        [Required]
        public int? TeamId { get; set; }
        public IEnumerable<TeamDropdownViewModel>? Teams { get; set; }

        [Required]
        public int? SeasonId { get; set; }

        public IEnumerable<SeasonDropdownViewModel>? Seasons { get; set; } 
        public string? ImageUrl { get; set; }

    }

}
