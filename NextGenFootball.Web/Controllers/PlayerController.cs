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
            try
            {
                PlayerDetailsViewModel? player = await this.playerService.GetPlayerDetailsAsync(id);
                if (player == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
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
            try
            {
                if (!ModelState.IsValid)
                {
                    inputModel.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                    inputModel.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                    return View(inputModel);
                }
                string userId = this.GetUserId()!;
                bool isCreated = await this.playerService.CreatePlayerAsync(inputModel, userId);
                if (isCreated == false)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the player. Please try again.");
                    return RedirectToAction(nameof(Create));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
                string userId = this.GetUserId()!;
                PlayerEditViewModel? model = await this.playerService.GetPlayerForEditAsync(id, userId);
                if (model == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                model.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                model.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PlayerEditViewModel inputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    inputModel.Teams = await this.teamService.GetTeamDropdownViewModelsAsync();
                    inputModel.Seasons = await this.seasonService.GetSeasonsForDropdownAsync();
                    return View(inputModel);
                }
                string userId = this.GetUserId()!;
                bool isUpdated = await this.playerService.UpdatePlayerAsync(inputModel, userId);
                if (isUpdated == false)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the player. Please try again.");
                    return RedirectToAction(nameof(Edit), new { id = inputModel.Id });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
