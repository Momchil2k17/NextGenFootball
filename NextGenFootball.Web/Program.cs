using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
namespace NextGenFootball.Web
{
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.EntityFrameworkCore;
    using NextGenFootball.Data.Models;
    using NextGenFootball.Data.Repository;
    using NextGenFootball.Data.Repository.Interfaces;
    using NextGenFootball.Data.Seeding;
    using NextGenFootball.Data.Seeding.Interfaces;
    using NextGenFootball.Services.Core;
    using NextGenFootball.Services.Core.Interfaces;
    using NextGenFootball.Web.Infrastructure.Extensions;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            
            builder.Services
                .AddDbContext<NextGenFootballDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    ConfigureIdentity(builder.Configuration, options);
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<NextGenFootballDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login"; // or your login route
                options.AccessDeniedPath = "/Home/Forbidden"; ; // Point to your controller/action that shows the forbidden page
            });

            builder.Services.AddRepositories(typeof(ITeamRepository).Assembly);
            builder.Services.AddUserDefinedServices(typeof(ITeamService).Assembly);

            builder.Services.AddTransient<IIdentitySeeder, IdentitySeeder>();

            builder.Services.AddControllersWithViews();


            WebApplication? app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.SeedDefaultIdentity();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UserAdminRedirection();
            app.UserRefereeRedirection();
            app.UserLeagueManagerRedirection();
            app.UserCoachRedirection();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureIdentity(IConfigurationManager configurationManager, IdentityOptions identityOptions)
        {
            identityOptions.SignIn.RequireConfirmedEmail =
                configurationManager.GetValue<bool>($"IdentityConfig:SignIn:RequireConfirmedEmail");
            identityOptions.SignIn.RequireConfirmedAccount =
                configurationManager.GetValue<bool>($"IdentityConfig:SignIn:RequireConfirmedAccount");
            identityOptions.SignIn.RequireConfirmedPhoneNumber =
                configurationManager.GetValue<bool>($"IdentityConfig:SignIn:RequireConfirmedPhoneNumber");

            identityOptions.Password.RequiredLength =
                configurationManager.GetValue<int>($"IdentityConfig:Password:RequiredLength");
            identityOptions.Password.RequireNonAlphanumeric =
                configurationManager.GetValue<bool>($"IdentityConfig:Password:RequireNonAlphanumeric");
            identityOptions.Password.RequireDigit =
                configurationManager.GetValue<bool>($"IdentityConfig:Password:RequireDigit");
            identityOptions.Password.RequireLowercase =
                configurationManager.GetValue<bool>($"IdentityConfig:Password:RequireLowercase");
            identityOptions.Password.RequireUppercase =
                configurationManager.GetValue<bool>($"IdentityConfig:Password:RequireUppercase");
            identityOptions.Password.RequiredUniqueChars =
                configurationManager.GetValue<int>($"IdentityConfig:Password:RequiredUniqueChars");
        }
    }
}
