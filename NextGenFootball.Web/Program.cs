namespace NextGenFootball.Web
{
    using Data;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.EntityFrameworkCore;
    using NextGenFootball.Data.Models;
    using NextGenFootball.Data.Repository;
    using NextGenFootball.Data.Repository.Interfaces;
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
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<NextGenFootballDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IStadiumRepository, StadiumRepository>();
            builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();
            builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<ICoachRepository, CoachRepository>();
            builder.Services.AddScoped<IMatchRepository, MatchRepository>();

            builder.Services.AddUserDefinedServices(typeof(ITeamService).Assembly);

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
