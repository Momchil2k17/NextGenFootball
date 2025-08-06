using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;
using NextGenFootball.Web.ViewModels.Player;

namespace NextGenFootball.Web.Areas.CoachManagement.Controllers
{
    public class LineupController : BaseCoachController
    {
        private readonly ICoachService coachService;
        private readonly IFormationService formationService;
        public LineupController(ICoachService coachService, IFormationService formationService)
        {
            this.coachService = coachService;
            this.formationService = formationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Choose()
        {
            Guid? applicationUserId = this.GetUserId();
            if (applicationUserId == null)
            {
                return View("BadRequest", "User ID is not available.");
            }
            var coach = await coachService.GetCoachByApplicationUserId(applicationUserId.Value);
            if (coach == null)
            {
                return View("BadRequest", "No coach found for this user.");
            }

            var players = await coachService.GetPlayersForCoach(applicationUserId);
            var formations = formationService.GetFormationsForCoach();
            var teamId = await coachService.GetCoachTeamId(applicationUserId.Value);

            var model = new CoachLineupViewModel
            {
                Players = players!,
                Formations = formations,
                SelectedFormationName = formations.FirstOrDefault()?.Name ?? "4-3-3",
                TeamId = teamId,
                CoachId = coach.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Choose(CoachLineupViewModel model)
        {
            Guid? applicationUserId = this.GetUserId();
            if (applicationUserId == null)
            {
                return View("BadRequest", "User ID is not available.");
            }

            var coach = await coachService.GetCoachByApplicationUserId(applicationUserId.Value);
            if (coach == null)
            {
                return View("BadRequest", "No coach found for this user.");
            }

            model.CoachId = coach.Id;
            model.TeamId = await coachService.GetCoachTeamId(applicationUserId.Value);

            var formations = formationService.GetFormationsForCoach();
            var players = await coachService.GetPlayersForCoach(applicationUserId.Value);

            var selectedFormation = formations.FirstOrDefault(f => f.Name == model.SelectedFormationName);
            if (selectedFormation == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid formation selected.");
                model.Formations = formations;
                model.Players = players;
                return View(model);
            }

            if (model.SelectedPlayers.Count != selectedFormation.Positions.Count)
            {
                ModelState.AddModelError(string.Empty, "Please assign a player to every position in the selected formation.");
                model.Formations = formations;
                model.Players = players!;
                return View(model);
            }
            await coachService.SaveStartingLineupFromViewModelAsync(model, coach.Id);

            return RedirectToAction("Index","Home");
        }

    }
}
