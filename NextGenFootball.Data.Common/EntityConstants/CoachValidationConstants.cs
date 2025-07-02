using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class CoachValidationConstants
    {
        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 50;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 50;

        public const int PhoneNumberMinLength = 9;
        public const int PhoneNumberMaxLength = 15;

        public const int ImageUrlMaxLength = 2048;
    }
}
