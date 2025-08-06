using NextGenFootball.Web.ViewModels.News;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface INewsService
    {
        public Task<IEnumerable<NewsIndexViewModel>?> GetAllNewsAsync();
        public Task<NewsDetailsViewModel?> GetNewsDetailsAsync(int? id);
        public Task<bool> CreateNewsAsync(NewsCreateViewModel model);
        public Task<(IEnumerable<NewsIndexViewModel> News, int TotalItems)> SearchNewsAsync(string? searchTerm, int page, int pageSize);
        public Task<IEnumerable<NewsIndexViewModel>?> GetLatestNewsAsync(int count);
        public Task<NewsEditViewModel?> GetNewsForEditAsync(int? id);
        public Task<bool> EditNewsAsync(NewsEditViewModel model);
    }
}
