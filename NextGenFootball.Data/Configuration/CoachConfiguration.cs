using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.CoachValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> entity)
        {
            entity
                .HasKey(c => c.Id);

            entity
                .HasIndex(c => c.TeamId);
            entity
                .HasIndex(c => c.ApplicationUserId);

            entity
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameMaxLength);

            entity
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(LastNameMaxLength);

            entity
                .Property(c => c.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(PhoneNumberMaxLength);

            entity
               .Property(p => p.ImageUrl)
               .IsRequired(false)
               .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasOne(c => c.Team)
                .WithMany(t => t.Coaches)
                .HasForeignKey(c => c.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(c => c.ApplicationUser)
                .WithMany(u => u.Coaches)
                .HasForeignKey(c => c.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasQueryFilter(p => p.IsDeleted == false);

        }
    }
}
