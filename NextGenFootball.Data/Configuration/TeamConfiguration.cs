using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.TeamValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> entity)
        {
            entity.
                HasKey(t => t.Id);

            entity
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(t => t.Region)
                .IsRequired();

            entity
                .Property(t=>t.AgeGroup)
                .IsRequired()
                .HasMaxLength(AgeGroupMaxLength);

            entity
                .Property(t => t.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(t => t.Description)
                .IsRequired(false)
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(t => t.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasOne(t => t.Stadium)
                .WithMany(s => s.Teams)
                .HasForeignKey(t => t.StadiumId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(t => t.League)
                .WithMany(l => l.Teams)
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.Restrict);

            //possibility to filter out soft-deleted stadiums and leagues
            entity
                .HasQueryFilter(t => t.IsDeleted==false);

            
        }
    }
}
