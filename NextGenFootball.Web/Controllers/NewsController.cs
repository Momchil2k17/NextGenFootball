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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isCreated = await this.newsService.CreateNewsAsync(model);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Failed to create news.");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Search(string searchTerm, int page = 1, int pageSize = 9)
        {
            var (news, totalItems) = await newsService.SearchNewsAsync(searchTerm, page, pageSize);

            var result = new
            {
                items = news,
                currentPage = page,
                totalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };

            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var news = await newsService.GetNewsForEditAsync(id.Value);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(NewsEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isEdited = await this.newsService.EditNewsAsync(model);
            if (!isEdited)
            {
                ModelState.AddModelError(string.Empty, "Failed to edit news.");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
