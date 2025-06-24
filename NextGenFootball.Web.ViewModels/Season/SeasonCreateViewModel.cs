using NextGenFootball.Data.Common.EntityConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.SeasonValidationConstants;

namespace NextGenFootball.Web.ViewModels.Season
{
    public class SeasonCreateViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Season name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
