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

            builder.Services.AddScoped<IStadiumService, StadiumService>();
            builder.Services.AddScoped<ISeasonService, SeasonService>();
            builder.Services.AddScoped<ILeagueService, LeagueService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<IPlayerService, PlayerService>();

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
