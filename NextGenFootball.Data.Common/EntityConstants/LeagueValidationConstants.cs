using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class LeagueValidationConstants
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 100;

        public const int AgeGroupMinLength = 2;
        public const int AgeGroupMaxLength = 20;

        public const int DescriptionMaxLength = 500;

        public const int ImageUrlMaxLength = 2048; 
    }

    public static class LeagueValidationMessages
    {
        public const string NameRequired = "League name is required.";
        public const string NameLength = "League name must be between {2} and {1} characters.";

        public const string AgeGroupRequired = "Age group is required.";
        public const string AgeGroupLength = "Age group must be between {2} and {1} characters.";

        public const string RegionRequired = "Region is required.";

        public const string SeasonIdRequired = "Season is required.";

        public const string ImageUrlLength = "Image URL must not exceed {1} characters.";

        public const string DescriptionLength = "Description must not exceed {1} characters.";
    }

}
