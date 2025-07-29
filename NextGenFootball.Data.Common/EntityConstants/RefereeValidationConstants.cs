using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class RefereeValidationConstants
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 50;

        public const int PhoneNumberMinLength = 9;
        public const int PhoneNumberMaxLength = 15;

        public const int EmailMaxLength = 100;

        public const int ImageUrlMaxLength = 2048;
    }
    public static class RefereeValidationMessages
    {
        public const string FirstNameRequired = "First name is required.";
        public const string FirstNameLength = "First name must be between {2} and {1} characters.";

        public const string LastNameRequired = "Last name is required.";
        public const string LastNameLength = "Last name must be between {2} and {1} characters.";

        public const string PhoneNumberRequired = "Phone number is required.";
        public const string PhoneNumberLength = "Phone number must be between {2} and {1} digits.";

        public const string EmailRequired = "Email is required.";
        public const string EmailLength = "Email must not exceed {1} characters.";
        public const string EmailInvalid = "Invalid email format.";


        public const string ImageUrlLength = "Image URL must not exceed {1} characters.";
    }
}
