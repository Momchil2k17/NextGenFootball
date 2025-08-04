using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Web.Infrastructure.Middlewares
{
    public class CoachManagementRedirectionMiddleware
    {
        private const string IndexPath = "/";
        private const string CoachManagementIndexPath = "/CoachManagement";

        private readonly RequestDelegate next;

        public CoachManagementRedirectionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (context.Request.Path == IndexPath &&
                    context.User.IsInRole(CoachRoleName))
                {
                    context.Response.Redirect(CoachManagementIndexPath);

                    return;
                }
            }

            await this.next(context);
        }
    }
}
