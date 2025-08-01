using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.Data.Common.EntityConstants.SeasonValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> entity)
        {
            entity
                .HasKey(s => s.Id);

            entity
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(s=>s.IsDeleted)
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(s => s.IsDeleted==false);

            entity
                .HasData(this.SeedSeasons());
        }
        private IEnumerable<Season> SeedSeasons()
        {
            return new List<Season>
            {
                new Season
                {
                    Id = 1,
                    Name = "2025/2026",
                    StartDate = new DateTime(2025, 8, 1),
                    EndDate = new DateTime(2026, 5, 31),
                    IsCurrent=DateTime.Now>= new DateTime(2025, 8, 1) && DateTime.Now <= new DateTime(2026, 5, 31),
                    IsDeleted = false
                },
                new Season
                {
                    Id = 2,
                    Name = "2026/2027",
                    StartDate = new DateTime(2026, 8, 1),
                    EndDate = new DateTime(2027, 5, 31),
                    IsCurrent=DateTime.Now>= new DateTime(2026, 8, 1) && DateTime.Now <= new DateTime(2027, 5, 31),
                    IsDeleted = false
                },
                new Season
                {
                    Id = 3,
                    Name = "2027/2028",
                    StartDate = new DateTime(2027, 8, 1),
                    EndDate = new DateTime(2028, 5, 31),
                    IsCurrent=DateTime.Now>= new DateTime(2027, 8, 1) && DateTime.Now <= new DateTime(2028, 5, 31),
                    IsDeleted = false
                }
            };
        }
    }
}
