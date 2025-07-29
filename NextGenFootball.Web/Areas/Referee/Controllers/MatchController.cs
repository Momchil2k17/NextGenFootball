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
        [HttpGet]
        public async Task<IActionResult> CreateReport(long id)
        {
            MatchReportViewModel? reportViewModel = await this.refereeMatchService.GetMatchReportView(id);
            return View(reportViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReport(MatchReportViewModel matchReport)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateReport", new { id = matchReport.MatchId });
            }
            await this.refereeMatchService.CreateMatchReportAsync(matchReport);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditReport(long id)
        {
            MatchReportViewModel? reportViewModel = await this.refereeMatchService.GetMatchReportView(id);
            if (reportViewModel == null)
            {
                return NotFound();
            }
            return View(reportViewModel);
        }
    }
}
