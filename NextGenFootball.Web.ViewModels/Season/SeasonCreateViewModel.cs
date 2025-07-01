using NextGenFootball.Data.Common.EntityConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.SeasonValidationConstants;
using static NextGenFootball.Data.Common.EntityConstants.SeasonValidationMessages;

namespace NextGenFootball.Web.ViewModels.Season
{
    public class SeasonCreateViewModel
    {
        [Required(ErrorMessage = SeasonNameRequiredMessage)]
        [StringLength(
            NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = SeasonNameLengthMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = SeasonStartDateRequiredMessage)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = SeasonEndDateRequiredMessage)]
        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
