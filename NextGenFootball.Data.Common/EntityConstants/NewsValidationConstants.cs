using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.EntityConstants
{
    public static class NewsValidationConstants
    {
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 150;

        public const int ContentMinLength = 20;
        public const int ContentMaxLength = 10000;

        public const int AuthorMinLength = 2;
        public const int AuthorMaxLength = 100;

        public const int TagMinLength = 2;
        public const int TagMaxLength = 100;

        public const int ImageUrlMaxLength = 2048;
    }
    public static class NewsValidationMessages
    {
        public const string TitleRequired = "Title is required.";
        public const string TitleLength = "Title must be between {2} and {1} characters.";

        public const string ContentRequired = "Content is required.";
        public const string ContentLength = "Content must be between {2} and {1} characters.";

        public const string AuthorRequired = "Author is required.";
        public const string AuthorLength = "Author name must be between {2} and {1} characters.";

        public const string ImageUrlLength = "Image URL must not exceed {1} characters.";
    }
}
