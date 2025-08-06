using NextGenFootball.Data.Common.EntityConstants;
using System.ComponentModel.DataAnnotations;
using static NextGenFootball.Data.Common.EntityConstants.RefereeValidationConstants;
using static NextGenFootball.Data.Common.EntityConstants.RefereeValidationMessages;

namespace NextGenFootball.Web.ViewModels.RefereeManagement
{
    public class RefereeCreateViewModel
    {
        public Guid? ApplicationUserId { get; set; }

        [Required(ErrorMessage =FirstNameRequired)]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = FirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = LastNameRequired)]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = LastNameLength)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = PhoneNumberRequired)]
        [StringLength(PhoneNumberMaxLength, MinimumLength =PhoneNumberMinLength, ErrorMessage = PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = EmailRequired)]
        [StringLength(EmailMaxLength, ErrorMessage = EmailLength)]
        [EmailAddress(ErrorMessage = EmailInvalid)]
        public string Email { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlLength)]
        public string? ImageUrl { get; set; }
    }
}
