using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Seeding.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Data.Seeding
{
    public class IdentitySeeder : IIdentitySeeder
    {
        private readonly string[] DefaultRoles = { AdminRoleName, UserRoleName, RefereeRoleName };

        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserStore<ApplicationUser> userStore;
        private readonly IUserEmailStore<ApplicationUser> emailStore;
        private readonly IConfiguration configuration;

        public IdentitySeeder(
            RoleManager<IdentityRole<Guid>> roleManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            IConfiguration configuration)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.userStore = userStore;
            this.configuration = configuration;

            this.emailStore = this.GetEmailStore();
        }

        public async Task SeedIdentityAsync()
        {
            await this.SeedRolesAsync();
            await this.SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            foreach (string defaultRole in DefaultRoles)
            {
                bool roleExists = await this.roleManager.RoleExistsAsync(defaultRole);
                if (!roleExists)
                {
                    var newRole = new IdentityRole<Guid>(defaultRole);
                    var result = await this.roleManager.CreateAsync(newRole);
                    if (!result.Succeeded)
                    {
                        throw new Exception($"There was an exception while seeding the {defaultRole} role!");
                    }
                }
            }
        }

        private async Task SeedUsersAsync()
        {
            string? testUserEmail = this.configuration["UserSeed:TestUser:Email"];
            string? testUserPassword = this.configuration["UserSeed:TestUser:Password"];
            string? adminUserEmail = this.configuration["UserSeed:TestAdmin:Email"];
            string? adminUserPassword = this.configuration["UserSeed:TestAdmin:Password"];
            string? refereeUserEmail = this.configuration["UserSeed:TestReferee:Email"];
            string? refereeUserPassword = this.configuration["UserSeed:TestReferee:Password"];

            if (testUserEmail == null || testUserPassword == null ||
                adminUserEmail == null || adminUserPassword == null ||
                refereeUserEmail == null || refereeUserPassword == null)
            {
                throw new Exception("Missing configuration values for seeding users.");
            }

            await CreateUserIfNotExists(testUserEmail, testUserPassword, UserRoleName);
            await CreateUserIfNotExists(adminUserEmail, adminUserPassword, AdminRoleName);
            await CreateUserIfNotExists(refereeUserEmail, refereeUserPassword, RefereeRoleName);
        }

        private async Task CreateUserIfNotExists(string email, string password, string role)
        {
            ApplicationUser? existingUser = await this.userStore.FindByNameAsync(email, CancellationToken.None);
            if (existingUser == null)
            {
                ApplicationUser user = new ApplicationUser();
                await this.userStore.SetUserNameAsync(user, email, CancellationToken.None);
                await this.emailStore.SetEmailAsync(user, email, CancellationToken.None);

                var result = await this.userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to seed user: {email}");
                }

                result = await this.userManager.AddToRoleAsync(user, role);
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to assign role {role} to user: {email}");
                }
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!this.userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The user store must support email.");
            }

            return (IUserEmailStore<ApplicationUser>)this.userStore;
        }
    }
}
