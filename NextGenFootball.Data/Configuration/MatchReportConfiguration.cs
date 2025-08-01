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
