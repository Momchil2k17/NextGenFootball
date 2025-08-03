using NextGenFootball.Data.Common.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface ISearchService
    {
        public Task<List<SearchResult>> AutocompleteAsync(string query);
    }
}
