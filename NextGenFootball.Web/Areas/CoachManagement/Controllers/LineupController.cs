using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;

namespace NextGenFootball.Web.Areas.CoachManagement.Controllers
{
    public class LineupController : BaseCoachController
    {
        private readonly ICoachService coachService;
        public LineupController(ICoachService coachService)
        {
            this.coachService = coachService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Choose()
        {
            Guid? userId = this.GetUserId();
            if (userId == null)
            {
                return BadRequest("User ID is not available.");
            }
            try
            {
                var players = await this.coachService.GetPlayersForCoach(userId.Value);
                if (players == null || !players.Any())
                {
                    ModelState.AddModelError(string.Empty, "No players found for the coach.");
                    return View();
                }
                var formations = this.coachService.GetFormationsForCoach();

                var model = new CoachLineupViewModel
                {
                    Players = players,
                    Formations = formations,
                    SelectedFormationName = formations.First().Name
                };

                return View(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View();
            }
        }
    }
}
