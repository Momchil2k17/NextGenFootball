using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
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

            entity
                .HasQueryFilter(t => t.IsDeleted==false);

            entity.
                HasData(this.SeedTeams());
        }
        public IEnumerable<Team> SeedTeams() 
        {
            List<Team> teams = new List<Team>()
            {
                new Team
                {
                    Id = 1,
                    Name = "CSKA Sofia U15",
                    Region = Region.ЮгозападнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/CSKA_Sofia_logo.svg/471px-CSKA_Sofia_logo.svg.png",
                    Description = "CSKA Sofia's youth team, based in Sofia.",
                    StadiumId = 1,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 2,
                    Name = "Ludogorets Razgrad U15",
                    Region = Region.СевероизточнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/eb/PFC_Ludogorets_Razgrad_logo.png",
                    Description = "Ludogorets Razgrad's youth team.",
                    StadiumId = 2,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 3,
                    Name = "Levski Sofia U15",
                    Region = Region.ЮгозападнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/51/PFC_Levski_Sofia.svg",
                    Description = "Levski Sofia's U15 team.",
                    StadiumId = 3,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 4,
                    Name = "Beroe Stara Zagora U15",
                    Region = Region.ЮгоизточнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/df/BeroeLogo.png",
                    Description = "Beroe Stara Zagora's U15 team.",
                    StadiumId = 4,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 5,
                    Name = "Botev Plovdiv U15",
                    Region = Region.ЮгоизточнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/87/PFC_Botev_Plovdiv.svg/640px-PFC_Botev_Plovdiv.svg.png",
                    Description = "Botev Plovdiv's youth team.",
                    StadiumId = 5,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 6,
                    Name = "Lokomotiv Plovdiv U15",
                    Region = Region.ЮгоизточнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/12/PFC_Lokomotiv_Plovdiv.png",
                    Description = "Lokomotiv Plovdiv's U15 squad.",
                    StadiumId = 6,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 7,
                    Name = "Etar Veliko Tarnovo U15",
                    Region = Region.СеверозападнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://etarvt.bg/wp-content/uploads/2017/03/etar.png",
                    Description = "Etar Veliko Tarnovo's U15 team.",
                    StadiumId = 7,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 8,
                    Name = "Slavia Sofia U15",
                    Region = Region.ЮгозападнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a3/Slavia-Sofia.png",
                    Description = "Slavia Sofia's U15 team.",
                    StadiumId = 8,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 9,
                    Name = "Cherno More Varna U15",
                    Region = Region.СевероизточнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://seeklogo.com/images/F/fk-cherno-more-varna-logo-FF1CA3BA17-seeklogo.com.gif",
                    Description = "Cherno More Varna U15 squad.",
                    StadiumId = 9,
                    LeagueId = 1
                },
                new Team
                {
                    Id = 10,
                    Name = "Dobrudzha Dobrich U15",
                    Region = Region.СевероизточнаБългария,
                    AgeGroup = "U15",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/09/FC_Dobrudzha_Dobrich_2018_emblem.png",
                    Description = "Dobrudzha Dobrich U15 youth team.",
                    StadiumId = 10,
                    LeagueId = 1
                }

            };
            return teams;
        }
    }
}
