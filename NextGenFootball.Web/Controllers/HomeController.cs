namespace NextGenFootball.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NextGenFootball.Data.Models;
    using NextGenFootball.Services.Core;
    using NextGenFootball.Services.Core.Interfaces;
    using NextGenFootball.Web.ViewModels.Home;
    using System.Diagnostics;
    using ViewModels;

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly INewsService newsService;
        private readonly ILeagueService leagueService;
        public HomeController(ILogger<HomeController> logger, ILeagueService leagueService,INewsService newsService)
        {
            this.leagueService = leagueService;
            this.newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var standingsVm = await leagueService.GetCurrentStandingsAsync();
            var matchesVm = await leagueService.GetUpcomingMatchesForHomeAsync();
            var newsVm = await newsService.GetLatestNewsAsync(3);

            var homeVm = new HomePageViewModel
            {
                Standings = standingsVm,
                UpcomingMatches = matchesVm,
                LatestNews = newsVm
            };
            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return this.View("BadRequest");
                case 401:
                    return this.View("Forbidden");
                case 403:
                    return this.View("Forbidden");
                case 404:
                    return this.View("NotFoundError");
                case 500:
                    return this.View("InternalServerError");
                default:
                    return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
        [Route("Home/Forbidden")]
        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
    }
}
