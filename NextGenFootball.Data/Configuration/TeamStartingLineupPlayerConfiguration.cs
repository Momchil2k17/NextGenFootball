using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Configuration
{
    public class TeamStartingLineupPlayerConfiguration : IEntityTypeConfiguration<TeamStartingLineupPlayer>

    {
        public void Configure(EntityTypeBuilder<TeamStartingLineupPlayer> entity)
        {
            entity
                .HasKey(t=>t.Id);

            entity
                .HasQueryFilter(t => !t.TeamStartingLineup.Team.IsDeleted && !t.Player.IsDeleted);
        }
    }
}
