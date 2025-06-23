namespace NextGenFootball.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using NextGenFootball.Data.Models;

    public class NextGenFootballDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public NextGenFootballDbContext(DbContextOptions<NextGenFootballDbContext> options)
            : base(options)
        {

        }
    }
}
