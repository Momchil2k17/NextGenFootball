using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;

namespace NextGenFootball.Web.Controllers
{
    public class CoachController : BaseController
    {
        private readonly ICoachService coachService;
        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<CoachIndexViewModel> coaches = await this.coachService.GetAllCoachesAsync();
            return View(coaches);
        }
    }
}
