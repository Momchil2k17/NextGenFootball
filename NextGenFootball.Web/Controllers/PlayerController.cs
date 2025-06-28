using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Player;

namespace NextGenFootball.Web.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<PlayerIndexViewModel> players = await this.playerService.GetAllPlayersAsync();
            return View(players);
        }
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
    }
}
