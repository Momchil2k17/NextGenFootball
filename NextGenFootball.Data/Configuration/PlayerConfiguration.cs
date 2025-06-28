using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.PlayerValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity
                .HasKey(p => p.Id);

            //for better performance, we can add indexes on foreign keys
            entity.HasIndex(p => p.TeamId);
            entity.HasIndex(p => p.SeasonId);
            entity.HasIndex(p => p.ApplicationUserId);

            entity
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Players)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(FirstNameMaxLength);

            entity
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(LastNameMaxLength);

            entity
                .Property(p => p.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(PhoneNumberMaxLength);

            entity
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(p => p.Season)
                .WithMany(s => s.Players)
                .HasForeignKey(p => p.SeasonId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .Property(p => p.DateOfBirth)
                .IsRequired();

            entity
                .Property(p => p.Position)
                .IsRequired()
                .HasMaxLength(PositionMaxLength);

            entity
                .Property(p => p.PreferredFoot)
                .IsRequired();

            entity
                .Property(p=>p.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(p=> p.IsDeleted == false);
        }
    }
}
