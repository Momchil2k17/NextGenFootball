using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.StadiumValidationConstants;
using static NextGenFootball.Data.Common.EntityConstants.StadiumValidationMessages;

namespace NextGenFootball.Web.ViewModels.Stadium
{
    public class StadiumCreateViewModel
    {
        [Required(ErrorMessage = NameRequired)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLength)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionMaxLength, ErrorMessage = DescriptionLength)]
        public string? Description { get; set; }

        [Required(ErrorMessage = AddressRequired)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = AddressLength)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = CapacityRequired)]
        [Range(CapacityMin, CapacityMax, ErrorMessage = CapacityRange)]
        public int Capacity { get; set; }

        [Required(ErrorMessage = SurfaceRequired)]
        public SurfaceType Surface { get; set; }

        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlLength)]
        [Url(ErrorMessage = ImageUrlInvalid)]
        public string? ImageUrl { get; set; }
    }
}
