using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.NewsValidationConstants;
using static NextGenFootball.Data.Common.EntityConstants.NewsValidationMessages;
namespace NextGenFootball.Web.ViewModels.News
{
    public class NewsCreateViewModel
    {
        [Required(ErrorMessage = TitleRequired)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = ContentRequired)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = ContentLength)]
        public string Content { get; set; } = null!;

        [Required(ErrorMessage = AuthorRequired)]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength, ErrorMessage = AuthorLength)]
        public string Author { get; set; } = null!;

        [StringLength(ImageUrlMaxLength, ErrorMessage = ImageUrlLength)]
        public string? ImageUrl { get; set; }
    }
}
