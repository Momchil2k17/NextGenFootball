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

            entity
                .HasData(this.SeedPlayers2());
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
        public IEnumerable<Player> SeedPlayers2()
        {
            List<Player> players = new List<Player>()
            {
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Sergio",
                    LastName = "Padt",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1990, 6, 6),
                    Position = "Goalkeeper",
                    PositionEnum = PositionEnum.Goalkeeper,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/79573-1753810372.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Anton",
                    LastName = "Nedyalkov",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1993, 4, 30),
                    Position = "Left Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Left,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/218441-1753810308.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Igor",
                    LastName = "Plastun",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1990, 8, 20),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/97335-1629575683.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Olivier",
                    LastName = "Verdon",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1995, 10, 6),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/504125-1753810743.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dominik",
                    LastName = "Yankov",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2000, 7, 28),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/541287-1740597154.jpg?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jakub",
                    LastName = "Piotrowski",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1997, 10, 4),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/377243-1691005537.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Claude",
                    LastName = "Gonçalves",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1994, 6, 9),
                    Position = "Defensive Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/280178-1721812558.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Kiril",
                    LastName = "Despodov",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1996, 11, 11),
                    Position = "Right Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/221540-1727967569.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bernard",
                    LastName = "Tekpetey",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1997, 9, 3),
                    Position = "Left Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/422380-1720984240.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Rick",
                    LastName = "Lourenço",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1995, 5, 23),
                    Position = "Right Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/645955-1720984771.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Matías",
                    LastName = "Tissera",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1996, 9, 6),
                    Position = "Center Forward",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/503001-1720984447.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dinis",
                    LastName = "Almeida",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1994, 6, 9),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/329519-1753810578.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Filip",
                    LastName = "Kaloc",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2000, 2, 27),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/396230-1753810681.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Rwan",
                    LastName = "Seco",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2001, 12, 20),
                    Position = "Center Forward",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/973569-1691005715.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Aslak",
                    LastName = "Fonn Witry",
                    TeamId = 2,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1996, 3, 10),
                    Position = "Right Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/313944-1691003407.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Svetoslav",
                    LastName = "Vutsov",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2002, 7, 9),
                    Position = "Goalkeeper",
                    PositionEnum = PositionEnum.Goalkeeper,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/628038-1754077358.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Kristian",
                    LastName = "Dimitrov",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1997, 2, 27),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Left,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/351800-1754077260.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Christian",
                    LastName = "Makoun",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2000, 3, 5),
                    Position = "Center Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/463667-1754077287.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jeremy",
                    LastName = "Petris",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1998, 6, 24),
                    Position = "Right Back",
                    PositionEnum = PositionEnum.Defender,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/532858-1688876742.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Welton",
                    LastName = "Felix",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1997, 2, 21),
                    Position = "Left Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/858213-1680124417.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Andrian",
                    LastName = "Kraev",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1999, 2, 14),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/820371-1680122620.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Iliyan",
                    LastName = "Stefanov",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1999, 9, 15),
                    Position = "Attacking Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/310144-1680123802.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ronaldo",
                    LastName = "Henrique",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2000, 4, 10),
                    Position = "Right Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/328758-1733317063.jpg?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Filip",
                    LastName = "Krastev",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2001, 10, 15),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://cdn.soccerwiki.org/images/player/104559.png",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Carlos",
                    LastName = "Ohene",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1993, 7, 21),
                    Position = "Center Forward",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/239998-1754075190.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Georgi",
                    LastName = "Milanov",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1992, 2, 19),
                    Position = "Central Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/134158-1732263336.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Darlan",
                    LastName = "Cruz",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1998, 4, 15),
                    Position = "Defensive Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/570582-1691301973.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Marin",
                    LastName = "Petkov",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(2003, 10, 2),
                    Position = "Right Winger",
                    PositionEnum = PositionEnum.Forward,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/675946-1754077435.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Nikolay",
                    LastName = "Mihaylov",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1988, 6, 28),
                    Position = "Goalkeeper",
                    PositionEnum = PositionEnum.Goalkeeper,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/24480-1681658070.png?lm=1",
                    IsDeleted = false
                },
                new Player
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Georgi",
                    LastName = "Kostadinov",
                    TeamId = 3,
                    SeasonId = 1,
                    DateOfBirth = new DateTime(1990, 9, 7),
                    Position = "Defensive Midfield",
                    PositionEnum = PositionEnum.Midfielder,
                    PreferredFoot = PreferredFoot.Right,
                    Goals = 0,
                    Assists = 0,
                    MinutesPlayed = 0,
                    YellowCards = 0,
                    RedCards = 0,
                    ImageUrl = "https://img.a.transfermarkt.technology/portrait/header/198816-1754075148.png?lm=1",
                    IsDeleted = false
                },
            };
            return players;
        }
    }
}
