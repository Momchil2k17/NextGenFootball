using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Match;

namespace NextGenFootball.Web.Controllers
{
    public class MatchController : BaseController
    {
        private readonly IMatchService matchService;
        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<MatchIndexViewModel> matches = await this.matchService.GetAllMatchesAsync();
            return View(matches);
        }
    }
}
