using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.Search
{
    public class SearchResult
    {
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Guid? PlayerId { get; set; }
        public int? TeamId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
