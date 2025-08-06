using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using static NextGenFootball.Data.Common.EntityConstants.StadiumValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
    {
        public void Configure(EntityTypeBuilder<Stadium> entity)
        {
            entity
                .HasKey(s => s.Id);

            entity
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            entity
                .Property(s => s.Description)
                .IsRequired(false)
                .HasMaxLength(DescriptionMaxLength);

            entity
                .Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(AddressMaxLength);

            entity
                .Property(s => s.Capacity)
                .IsRequired();

            entity
                .Property(s => s.Surface)
                .IsRequired();

            entity
                .Property(s => s.ImageUrl)
                .IsRequired(false)
                .HasMaxLength(ImageUrlMaxLength);

            entity
                .Property(s => s.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            entity
                .HasQueryFilter(s => s.IsDeleted == false);

            entity
                .HasData(this.SeedStadiums());
        }
        private IEnumerable<Stadium> SeedStadiums()
        {
            List<Stadium> stadiums = new List<Stadium>
                {
                    new Stadium
                    {
                        Id = 1,
                        Name = "Vasil Levski National Stadium",
                        Description = "National stadium located in Sofia.",
                        Address = "38, Evlogi and Hristo Georgiev Blvd., Sofia, Bulgaria",
                        Capacity = 44000,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://visitsofia.bg/images/vegas_media/category30000/object1137/bc9eda16929341c44a00f67d99a530c1.jpg"
                    },
                    new Stadium
                    {
                        Id = 2,
                        Name = "Ludogorets Arena",
                        Description = "Home of Ludogorets Razgrad.",
                        Address = "43 Vasil Levski Blvd., Razgrad, 7200, Bulgaria",
                        Capacity = 10222,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzvhxZ44u7BOCWfpkzkPiLGH-Qas9boXXs1w&s"
                    },
                    new Stadium
                    {
                        Id = 3,
                        Name = "Stadion Georgi Asparuhov",
                        Description = "Levski Sofia's stadium.",
                        Address = "47 Todorini Kukli Str., Sofia",
                        Capacity = 25000,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://sportenkalendar.bg/uploads/pages/stadion-georgi-asparuhov-639798c914d0a486224316.jpg"
                    },
                    new Stadium
                    {
                        Id = 4,
                        Name = "Stadion Beroe",
                        Description = "Located in Stara Zagora.",
                        Address = "ul. \"Beroe\" 10, 6000 Mitropolit Metodiy Kusev, Stara Zagora, Bulgaria",
                        Capacity = 12000,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://media.bgclubs.eu/images/stadiums/112/thumbnails/d6ae5e07b3c651e3e701cda939794851.jpg"
                    },
                    new Stadium
                    {
                        Id = 5,
                        Name = "Stadion Hristo Botev",
                        Description = "Home of Botev Plovdiv.",
                        Address = "Hristo Botev 10 Iztochen Blvd 4017 Plovdiv ",
                        Capacity = 18000,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://pimkbuild.bg/wp-content/uploads/2023/07/stadion-3.jpg"
                    },
                    new Stadium
                    {
                        Id = 6,
                        Name = "Stadion Lokomotiv",
                        Description = "Lokomotiv Plovdiv stadium.",
                        Address = "Lokomotiv Trakia Stadium",
                        Capacity = 13500,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7d/Lokomotiv_Stadium_2022.jpg"
                    },
                    new Stadium
                    {
                        Id = 7,
                        Name = "Stadion Ivaylo",
                        Description = "Located in Veliko Tarnovo.",
                        Address = "2 Ivaylo St, 5000 Veliko Tarnovo",
                        Capacity = 18000,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "Stadium Ivaylo Veliko Tarnovo"
                    },
                    new Stadium
                    {
                        Id = 8,
                        Name = "Stadion Slavia",
                        Description = "Home of Slavia Sofia.",
                        Address = "1 Koloman Str., Krasno selo",
                        Capacity = 25000,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://static.bnr.bg/gallery/cr/medium/4161fc0a6d52093f9345b9b7bbe11457.JPG"
                    },
                    new Stadium
                    {
                        Id = 9,
                        Name = "Stadion Ticha",
                        Description = "Cherno More Varna's stadium.",
                        Address = "Ticha Stadium",
                        Capacity = 8500,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://media.bgclubs.eu/images/stadiums/110/thumbnails/f0f8d88415e703b90b7ad27fbab55f88.jpg"
                    },
                    new Stadium
                    {
                        Id = 10,
                        Name = "Stadion Druzhba",
                        Description = "Located in Dobrich.",
                        Address = "Stadium \"Druzhba\"",
                        Capacity = 12000,
                        Surface = SurfaceType.Grass,
                        ImageUrl = "https://pronewsdobrich.bg//i/2024/09/17/461251.jpg"
                    }
                };
            return stadiums;
        }
    }
}
