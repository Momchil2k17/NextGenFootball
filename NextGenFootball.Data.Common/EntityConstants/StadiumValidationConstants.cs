using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class StadiumValidationConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 100;

        public const int DescriptionMaxLength = 1000;

        public const int AddressMinLength = 5;
        public const int AddressMaxLength = 200;

        public const int CapacityMin = 0;
        public const int CapacityMax = 150_000;

        public const int ImageUrlMaxLength = 2048;
    }
    public static class StadiumValidationMessages
    {
        public const string NameRequired = "Name is required.";
        public const string NameLength = "The Name must be between {2} and {1} characters.";

        public const string DescriptionLength = "The Description must be less than {1} characters.";

        public const string AddressRequired = "Address is required.";
        public const string AddressLength = "The Address must be between {2} and {1} characters.";

        public const string CapacityRequired = "Capacity is required.";
        public const string CapacityRange = "Capacity must be between {1} and {2}.";

        public const string SurfaceRequired = "Surface is required.";

        public const string ImageUrlLength = "The Image URL must be less than {1} characters.";
        public const string ImageUrlInvalid = "The ImageUrl must be a valid URL.";
    }
}
