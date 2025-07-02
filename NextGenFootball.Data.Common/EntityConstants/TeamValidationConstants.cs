using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class TeamValidationConstants
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 100;

        public const int AgeGroupMinLength = 2;
        public const int AgeGroupMaxLength = 20;

        public const int DescriptionMaxLength = 500;

        public const int ImageUrlMaxLength = 2048;
    }
    public static class TeamValidationMessages
    {
        public const string NameRequired = "Team name is required.";
        public const string NameLength = "Team name must be between {2} and {1} characters.";

        public const string AgeGroupRequired = "Age group is required.";
        public const string AgeGroupLength = "Age group must be between {2} and {1} characters.";

        public const string RegionRequired = "Region is required.";

        public const string LeagueRequired = "League is required.";

        public const string StadiumRequired = "Stadium is required.";

        public const string ImageUrlLength = "Image URL must not exceed {1} characters.";

        public const string DescriptionLength = "Description must not exceed {1} characters.";
    }
}
