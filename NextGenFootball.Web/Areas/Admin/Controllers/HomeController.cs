using Microsoft.AspNetCore.Mvc;

namespace NextGenFootball.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
