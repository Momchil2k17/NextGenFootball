using Microsoft.AspNetCore.Mvc;

namespace NextGenFootball.Web.Areas.Referee.Controllers
{
    public class HomeController : BaseRefereeController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
