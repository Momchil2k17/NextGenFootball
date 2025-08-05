using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
