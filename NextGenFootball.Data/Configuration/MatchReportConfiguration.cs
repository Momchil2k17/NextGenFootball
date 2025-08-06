using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;

namespace NextGenFootball.Data.Configuration
{
    public class MatchReportConfiguration : IEntityTypeConfiguration<MatchReport>
    {
        public void Configure(EntityTypeBuilder<MatchReport> entity)
        {
            entity
                .HasKey(mr => mr.Id);

            entity
                .HasQueryFilter(mr => !mr.Match!.IsDeleted);
        }
    }
}
