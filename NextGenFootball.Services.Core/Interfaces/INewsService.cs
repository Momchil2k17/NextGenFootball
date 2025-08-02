using NextGenFootball.Web.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface INewsService
    {
        public Task<IEnumerable<NewsIndexViewModel>?> GetAllNewsAsync();
        public Task<NewsDetailsViewModel?> GetNewsDetailsAsync(int? id);
    }
}
