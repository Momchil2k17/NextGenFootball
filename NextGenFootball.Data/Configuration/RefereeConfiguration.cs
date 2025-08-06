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
            entity
                .HasData(this.SeedReferees());
        }
        public IEnumerable<Referee> SeedReferees()
        {
            List<Referee> referees = new List<Referee>
            {
                new Referee
            {
                Id = Guid.Parse("5d9f7f6a-3f8a-4e65-bf97-1c5a2f1e2a10"),
                ApplicationUserId = null,
                FirstName = "Georgi",
                LastName = "Kabakov",
                PhoneNumber = "0889123456",
                Email = "georgi.kabakov@ref.bg",
                ImageUrl = null,
                IsDeleted = false
            },
            new Referee
            {
                Id = Guid.Parse("f2b7e3d0-4c2a-4b31-9e7a-2d4f7e6b8c21"),
                ApplicationUserId = null,
                FirstName = "Ivan",
                LastName = "Stoyanov",
                PhoneNumber = "0898123456",
                Email = "ivan.stoyanov@ref.bg",
                ImageUrl = null,
                IsDeleted = false
            },
            new Referee
            {
                Id = Guid.Parse("cc5a9e88-d7f4-4c6e-9e8b-3e7f9f8d2b32"),
                ApplicationUserId = null,
                FirstName = "Nikola",
                LastName = "Popov",
                PhoneNumber = "0877123456",
                Email = "nikola.popov@ref.bg",
                ImageUrl = null,
                IsDeleted = false
            },
            new Referee
            {
                Id = Guid.Parse("b3e9e6b0-8f4c-4a6c-8d7e-4f9e8e7c3d43"),
                ApplicationUserId = null,
                FirstName = "Petar",
                LastName = "Krastev",
                PhoneNumber = "0888123456",
                Email = "petar.krastev@ref.bg",
                ImageUrl = null,
                IsDeleted = false
            },
            new Referee
            {
                Id = Guid.Parse("a2c8e7f9-6e5d-4b4a-8c3e-5f7d9f6b4e54"),
                ApplicationUserId = null,
                FirstName = "Dimitar",
                LastName = "Mihaylov",
                PhoneNumber = "0897123456",
                Email = "dimitar.mihaylov@ref.bg",
                ImageUrl = null,
                IsDeleted = false
            }
            };
            return referees;
        }
    }
}
