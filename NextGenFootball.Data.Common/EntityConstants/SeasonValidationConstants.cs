using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class SeasonValidationConstants
    {
        public const int NameMaxLength = 20;
        public const int NameMinLength = 4;

        public static readonly DateTime MinStartDate = new DateTime(1900, 1, 1);
        public static readonly DateTime MaxEndDate = new DateTime(2100, 12, 31);
    }
}
