using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
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

            entity
                .HasData(this.SeedCoaches());

        }
        private IEnumerable<Coach> SeedCoaches()
        {
            List<Coach> coaches = new List<Coach>
                {
                    new Coach
                    {
                        Id = Guid.Parse("e6b7a0b8-9f40-4c26-9a9d-1a1e6b2f1a01"),
                        ApplicationUserId = null,
                        FirstName = "Jürgen",
                        LastName = "Klopp",
                        Role = CoachRole.HeadCoach,
                        PhoneNumber = "+359888111222",
                        TeamId = 1,
                        ImageUrl = "https://img.a.transfermarkt.technology/portrait/big/118-1736865351.jpg?lm=1",
                        IsDeleted = false
                    },
                    new Coach
                    {
                        Id = Guid.Parse("b2fa78d3-0e5d-46e2-bc2e-2a9f0d8f5c02"),
                        ApplicationUserId = null,
                        FirstName = "José",
                        LastName = "Mourinho",
                        Role = CoachRole.HeadCoach,
                        PhoneNumber = "+359888333444",
                        TeamId = 2,
                        ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/781-1717168225.jpg?lm=1",
                        IsDeleted = false
                    },
                    new Coach
                    {
                        Id = Guid.Parse("5e8c2a51-8d6f-4013-bd8f-3fae16b2a803"),
                        ApplicationUserId = null,
                        FirstName = "Alex",
                        LastName = "Ferguson",
                        Role = CoachRole.HeadCoach,
                        PhoneNumber = "+359888555666",
                        TeamId = 3,
                        ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/_1344344740.jpg?lm=1",
                        IsDeleted = false
                    }
                };
            return coaches;
        }
    }
}
