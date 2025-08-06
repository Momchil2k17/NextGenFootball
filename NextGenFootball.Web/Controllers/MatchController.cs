using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Match;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Controllers
{
    [Authorize(Roles = LeagueManagerRoleName+","+AdminRoleName)]
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
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(long? id)
        {
            MatchDetailsViewModel? match = await this.matchService.GetMatchDetailsAsync(id);
            if (match == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }
        [HttpGet]
        public async Task<IActionResult> AddVideoToMatch(long? id)
        {
            AddVideoToMatchViewModel? model = await this.matchService.GetMatchForVideoAsync(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddVideoToMatch(AddVideoToMatchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isAdded = await this.matchService.AddVideoToMatchAsync(model);
            if (!isAdded)
            {
                ModelState.AddModelError(string.Empty, "Failed to add video to match. Please try again.");
                return View(model);
            }
            return RedirectToAction(nameof(Details), new { id = model.Id });
        }
    }
    
}
