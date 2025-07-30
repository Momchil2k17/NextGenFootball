using Microsoft.AspNetCore.Mvc;

namespace NextGenFootball.Web.Areas.LeagueManager.Controllers
{
    public class DashboardController : BaseLeagueManagerController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
