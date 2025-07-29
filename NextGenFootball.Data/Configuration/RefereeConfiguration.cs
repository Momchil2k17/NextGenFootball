using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.RefereeValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class RefereeConfiguration : IEntityTypeConfiguration<Referee>
    {
        public void Configure(EntityTypeBuilder<Referee> entity)
        {
            entity
                .HasKey(c => c.Id);

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
                .IsRequired()
                .HasMaxLength(PhoneNumberMaxLength);

            entity
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(EmailMaxLength);

            entity
               .Property(p => p.ImageUrl)
               .IsRequired(false)
               .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);
            
            entity
                .HasOne(c => c.ApplicationUser)
                .WithMany(u => u.Referees)
                .HasForeignKey(c => c.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasQueryFilter(p => p.IsDeleted == false);
        }
    }
}
