using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Infrastructure.Middlewares
{
    public class RefereeRedirectionMiddleware
    {
        private const string IndexPath = "/";
        private const string RefereeIndexPath = "/Referee";

        private readonly RequestDelegate next;

        public RefereeRedirectionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (context.Request.Path == IndexPath &&
                    context.User.IsInRole(RefereeRoleName))
                {
                    context.Response.Redirect(RefereeIndexPath);

                    return;
                }
            }

            await this.next(context);
        }
    }
}
