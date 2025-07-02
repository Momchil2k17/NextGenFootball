using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Player;

namespace NextGenFootball.Web.Controllers
{
    public class PlayerController : BaseController
    {
        private readonly IPlayerService playerService;
        private readonly ITeamService teamService;
        private readonly ISeasonService seasonService;
        public PlayerController(IPlayerService playerService, ITeamService teamService, ISeasonService seasonService)
        {
            this.playerService = playerService;
            this.teamService = teamService;
            this.seasonService = seasonService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<PlayerIndexViewModel> players = await this.playerService.GetAllPlayersAsync();
            return View(players);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            PlayerDetailsViewModel? player = await this.playerService.GetPlayerDetailsAsync(id);
            if (player == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            PlayerCreateViewModel model = new PlayerCreateViewModel();
            {
                //middle age
                model.DateOfBirth = new DateTime(2007, 1, 1);
                model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                inputModel.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(inputModel);
            }
            bool isCreated = await this.playerService.CreatePlayerAsync(inputModel);
            if (isCreated == false)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the player. Please try again.");
                return RedirectToAction(nameof(Create));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            PlayerEditViewModel? model = await this.playerService.GetPlayerForEditAsync(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
            model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PlayerEditViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                inputModel.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(inputModel);
            }

            bool isUpdated = await this.playerService.UpdatePlayerAsync(inputModel);
            if (isUpdated == false)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the player. Please try again.");
                return RedirectToAction(nameof(Edit), new { id = inputModel.Id });
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> EditStats(Guid? id)
        {
            PlayerStatsEditViewModel? model = await this.playerService.GetPlayerStatsForEditAsync(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditStats(PlayerStatsEditViewModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }
            bool isUpdated = await this.playerService.UpdatePlayerStatsAsync(inputModel);
            if (isUpdated == false)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the player stats. Please try again.");
                return RedirectToAction(nameof(EditStats), new { id = inputModel.Id });
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            PlayerDeleteViewModel? model = await this.playerService.GetPlayerForDeleteAsync(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(PlayerDeleteViewModel inputModel)
        {

            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool isDeleted = await this.playerService.DeletePlayerAsync(inputModel);
            if (isDeleted == false)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the player. Please try again.");
                return RedirectToAction(nameof(Delete), new { id = inputModel.Id });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
