using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Common.Enums;
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
                .IsRequired(false) // ApplicationUserId can be null if the player is not associated with a user
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

            entity
                .HasData(this.SeedPlayers1());
        }
        public IEnumerable<Player> SeedPlayers1()
        {
            List<Player> players = new List<Player>()
            {
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Gustavo",
                    LastName = "Busatto",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1990, 10, 23),
                    Position = "Goalkeeper",
                    PositionEnum = PositionEnum.Goalkeeper,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/136574-1624290491.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dimitar",
                    LastName = "Evtimov",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2001, 2, 28),
                    Position = "Goalkeeper",
                    PositionEnum = PositionEnum.Goalkeeper,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/198418-1624290529.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ivan",
                    LastName = "Turitsov",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1999, 7, 18),
                    Position = "Right Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/550466-1624290844.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Thibaut",
                    LastName = "Vion",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1993, 12, 11),
                    Position = "Left Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/188501-1624290803.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jurgen",
                    LastName = "Mattheij",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1993, 4, 1),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/188660-1624290573.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Brian",
                    LastName = "Cordoba",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1999, 4, 17),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/585356-1689009993.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Amos",
                    LastName = "Youga",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1992, 12, 8),
                    Position = "Defensive Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/203540-1624292062.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Stanislav",
                    LastName = "Shopov",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2002, 2, 23),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Both,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/486813-1691069350.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jonathan",
                    LastName = "Lindseth",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1996, 2, 25),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/234345-1691069138.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Tobias",
                    LastName = "Heintz",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1998, 7, 13),
                    Position = "Right Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/329714-1691069272.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Duckens",
                    LastName = "Nazon",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1994, 4, 7),
                    Position = "Center Forward",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/345763-1712923993.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Michael",
                    LastName = "Estrada",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1996, 4, 7),
                    Position = "Left Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/265481-1718722697.jpg?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Enes",
                    LastName = "Mahmutovic",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1997, 5, 22),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/329055-1689009945.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Lazar",
                    LastName = "Tufegdzic",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1997, 2, 22),
                    Position = "Central Attacking Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/257466-1735137816.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Menno",
                    LastName = "Koch",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1994, 7, 2),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/182578-1624290727.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Brayan",
                    LastName = "Moreno",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1998, 6, 17),
                    Position = "Left Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/778476-1708593480.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Marcelino",
                    LastName = "Carreazo",
                    TeamId = 1,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1999, 12, 17),
                    Position = "Right Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/572043-1691069387.png?lm=1",
                    IsDeleted = false
                }
            };
            return players;
        }
    }
}
