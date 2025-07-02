using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class PlayerValidationConstants
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 50;


        public const int PositionMinLength = 2;
        public const int PositionMaxLength = 50;

        public const int PhoneNumberMinLength = 9;
        public const int PhoneNumberMaxLength = 15;

        public const int ImageUrlMaxLength = 2048;
    }
    public static class PlayerValidationMessages
    {
        public const string FirstNameRequired = "First name is required.";
        public const string FirstNameLength = "First name must be between {2} and {1} characters.";

        public const string LastNameRequired = "Last name is required.";
        public const string LastNameLength = "Last name must be between {2} and {1} characters.";

        public const string DateOfBirthRequired = "Date of birth is required.";

        public const string PositionRequired = "Position is required.";
        public const string PositionLength = "Position must be between {2} and {1} characters.";

        public const string PreferredFootRequired = "Preferred foot is required.";

        public const string TeamRequired = "Team is required.";

        public const string SeasonRequired = "Season is required.";
    }
}
