using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.News
{
    public class NewsIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }= null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime PublishedOn { get; set; }
        public string? ImageUrl { get; set; }
    }
}
