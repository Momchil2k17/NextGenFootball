using Microsoft.AspNetCore.Mvc;

namespace NextGenFootball.Web.Areas.Referee.Controllers
{
    public class CalendarController : BaseRefereeController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
