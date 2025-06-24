using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Season;

namespace NextGenFootball.Web.Controllers
{
    public class SeasonController : BaseController
    {
        private readonly ISeasonService seasonService;
        public SeasonController(ISeasonService seasonService)
        {
            this.seasonService = seasonService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SeasonIndexViewModel> seasons = await this.seasonService.GetAllSeasonsAsync();
            return View(seasons);
        }
    }
}
