using Microsoft.AspNetCore.Mvc;

namespace NextGenFootball.Web.Areas.CoachManagement.Controllers
{
    public class HomeController : BaseCoachController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
