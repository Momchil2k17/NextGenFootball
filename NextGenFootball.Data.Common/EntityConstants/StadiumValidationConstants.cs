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
}
