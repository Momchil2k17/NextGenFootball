using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
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

            entity
                .HasData(this.SeedLeagues());
        }
        public IEnumerable<League> SeedLeagues()
        {
            List<League> leagues = new List<League>
            {
                new League
                {
                    Id = 1,
                    Name = "Елитна юношеска група до 15 г.",
                    AgeGroup = "U15",
                    Description = "",
                    ImageUrl = "https://marketplace.canva.com/EAGFNmKiY9s/1/0/1600w/canva-blue-soccer-sports-logo-rQrjayPQsF0.jpg",
                    Region = Region.България,
                    IsDeleted = false,
                    SeasonId = 1
                },
                new League
                {
                    Id = 2,
                    Name = "Елитна юношеска група до 16г.",
                    AgeGroup = "U16",
                    Description = "",
                    ImageUrl = "https://i.pinimg.com/736x/d4/c7/65/d4c765fb353b3901676a1bdbda3f9706.jpg",
                    Region = Region.България,
                    IsDeleted = false,
                    SeasonId = 1
                },
                new League
                {
                    Id = 3,
                    Name = "Елитна юношеска група до 17г.",
                    AgeGroup = "U17",
                    Description = "",
                    ImageUrl = "https://img.freepik.com/premium-vector/ball-with-three-spotting-stripe-football-league-logo_8296-13.jpg",
                    Region = Region.България,
                    IsDeleted = false,
                    SeasonId = 1
                },
            };
            return leagues;
        }
    }
}
