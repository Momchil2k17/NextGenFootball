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
using static NextGenFootball.Data.Common.EntityConstants.PlayerValidationMessages;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerCreateViewModel
    {
        [Required(ErrorMessage = FirstNameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLength)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = DateOfBirthRequired)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = PositionRequired)]
        [StringLength(PositionMaxLength, MinimumLength = PositionMinLength, ErrorMessage = PositionLength)]
        public string Position { get; set; } = null!;
        public PositionEnum PositionEnum { get; set; }


        [Required(ErrorMessage = PreferredFootRequired)]
        public PreferredFoot PreferredFoot { get; set; }

        [Required(ErrorMessage = TeamRequired)]
        public int TeamId { get; set; }
        public IEnumerable<TeamDropdownViewModel>? Teams { get; set; }

        [Required(ErrorMessage = SeasonRequired)]
        public int SeasonId { get; set; }
        public IEnumerable<SeasonDropdownViewModel>? Seasons { get; set; }

        public string? ImageUrl { get; set; }

    }

}
