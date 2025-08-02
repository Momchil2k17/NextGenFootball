using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.News;

namespace NextGenFootball.Web.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService newsService;
        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<NewsIndexViewModel>? news = await this.newsService.GetAllNewsAsync();
            return View(news);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            NewsDetailsViewModel? details = await this.newsService.GetNewsDetailsAsync(id);
            if (details == null)
            {
                return NotFound();
            }
            return View(details);
        }
    }
}
