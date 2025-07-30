using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Infrastructure.Middlewares
{
    public class LeagueManagerRedirectionMiddleware
    {
        private const string IndexPath = "/";
        private const string LeagueManagerIndexPath = "/LeagueManager";

        private readonly RequestDelegate next;

        public LeagueManagerRedirectionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (context.Request.Path == IndexPath &&
                    context.User.IsInRole(LeagueManagerRoleName))
                {
                    context.Response.Redirect(LeagueManagerIndexPath);

                    return;
                }
            }

            await this.next(context);
        }
    }
}
