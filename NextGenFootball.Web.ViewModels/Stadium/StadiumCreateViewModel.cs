using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.StadiumValidationConstants;

namespace NextGenFootball.Web.ViewModels.Stadium
{
    public class StadiumCreateViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The Name must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLength, ErrorMessage = "The Description must be less than {1} characters.")]
        public string? Description { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = "The Address must be between {2} and {1} characters.")]
        public string Address { get; set; } = null!;

        [Required]
        [Range(CapacityMin, CapacityMax, ErrorMessage = "Capacity must be between {1} and {2}.")]
        public int Capacity { get; set; }

        [Required]
        public SurfaceType Surface { get; set; }

        [StringLength(ImageUrlMaxLength, ErrorMessage = "The Image URL must be less than {1} characters.")]
        [Url(ErrorMessage = "The ImageUrl must be a valid URL.")]
        public string? ImageUrl { get; set; }
    }
}
