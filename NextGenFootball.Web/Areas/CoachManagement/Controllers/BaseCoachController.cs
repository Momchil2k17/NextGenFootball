using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Areas.CoachManagement.Controllers
{
    [Area(CoachAreaName)]
    [Authorize(Roles = CoachRoleName)]
    [AutoValidateAntiforgeryToken]

    public class BaseCoachController : Controller
    {
        private bool IsUserAuthenticated()
        {
            bool retRes = false;
            if (this.User.Identity != null)
            {
                retRes = this.User.Identity.IsAuthenticated;
            }

            return retRes;
        }

        protected Guid? GetUserId()
        {
            if (this.IsUserAuthenticated())
            {
                string? userIdString = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Guid.TryParse(userIdString, out Guid userId))
                {
                    return userId;
                }
            }

            return null;
        }
    }
}
