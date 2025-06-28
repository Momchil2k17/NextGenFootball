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
    }
}
