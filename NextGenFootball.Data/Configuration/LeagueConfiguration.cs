using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.LeagueValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> entity)
        {
            entity
                .HasKey(l => l.Id);

            entity
                .Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(l => l.AgeGroup)
                .IsRequired()
                .HasMaxLength(AgeGroupMaxLength);

            entity
                .Property(l => l.Description)
                .IsRequired(false)
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(l => l.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(l => l.Region)
                .IsRequired();

            entity
                .Property(l => l.IsDeleted)
                .HasDefaultValue(false);

            entity.HasOne(l => l.Season)
                .WithMany(s => s.Leagues)
                .HasForeignKey(l => l.SeasonId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasQueryFilter(l => l.IsDeleted == false);
        }
    }
}
