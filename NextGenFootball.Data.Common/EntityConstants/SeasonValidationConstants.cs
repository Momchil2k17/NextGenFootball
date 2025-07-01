using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class SeasonValidationConstants
    {
        public const int NameMinLength = 4;
        public const int NameMaxLength = 20;
    }
    public static class SeasonValidationMessages
    {
        public const string SeasonNameRequiredMessage = "{0} is required!";
        public const string SeasonNameLengthMessage = "{0} must be between {2} and {1} characters!";

        public const string SeasonStartDateRequiredMessage = "{0} is required!";
        public const string SeasonEndDateRequiredMessage = "{0} is required!";

        public const string SeasonEndDateAfterStartDateMessage = "End date must be after start date!";

        public const string SeasonDoesNotExistMessage = "The season does not exist.";
    }
}
