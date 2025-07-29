using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Referee.Interfaces;
using NextGenFootball.Web.ViewModels.Referee.RefereeMatches;

namespace NextGenFootball.Web.Areas.Referee.Controllers
{
    public class MatchController : BaseRefereeController
    {
        private readonly IRefereeMatchService refereeMatchService;
        public MatchController(IRefereeMatchService refereeMatchService)
        {
            this.refereeMatchService = refereeMatchService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<MyMatchesViewModel?> matches = await this.refereeMatchService.GetRefereeMatches(this.GetUserId());
            return View(matches);
        }
    }
}
