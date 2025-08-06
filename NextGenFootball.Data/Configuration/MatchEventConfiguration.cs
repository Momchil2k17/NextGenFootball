using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Configuration
{
    public class MatchEventConfiguration : IEntityTypeConfiguration<MatchEvent>
    {
        public void Configure(EntityTypeBuilder<MatchEvent> entity)
        {
            entity
                .HasKey(me => me.Id);

            entity
                .HasQueryFilter(me => !me.MatchReport!.Match!.IsDeleted);
        }
    }
}
