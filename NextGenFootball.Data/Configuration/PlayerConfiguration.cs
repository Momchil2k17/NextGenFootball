using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using static NextGenFootball.Data.Common.EntityConstants.PlayerValidationConstants;

namespace NextGenFootball.Data.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> entity)
        {
            entity
                .HasKey(p => p.Id);

            entity.HasIndex(p => p.TeamId);
            entity.HasIndex(p => p.SeasonId);
            entity.HasIndex(p => p.ApplicationUserId);

            entity
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.Players)
                .HasForeignKey(p => p.ApplicationUserId)
                .IsRequired(false) 
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
                    Id = Guid.Parse("a0415484-d6c7-4810-8c8c-7efc69d0ae9d"),
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
                    Id = Guid.Parse("2e0b3b97-c5a0-4336-ae22-ef17a87c2843"),
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
                    Id = Guid.Parse("3694f527-8277-4e09-b861-ba8276910273"),
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
                    Id = Guid.Parse("fea3badc-0c3e-4249-9272-a54e3ed4b2ff"),
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
                    Id = Guid.Parse("a2fb3e65-e3f4-4348-8335-5f4667e83c22"),
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
                    Id = Guid.Parse("56b3ff5e-7fde-49a8-99da-dc76833396b3"),
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
                    Id = Guid.Parse("9778c700-13ec-4cec-8e08-daa9577cea67"),
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
                    Id = Guid.Parse("0efa81c3-9bd7-49a1-a5ce-8afd283a6c6e"),
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
                    Id = Guid.Parse("5a8967a3-0261-42a0-9841-16e52732f934"),
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
                    Id = Guid.Parse("1f4fb01d-52e7-4639-84b8-74107835f401"),
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
                    Id = Guid.Parse("f70355d9-0782-48f8-bd22-81d0fc9d8608"),
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
                    Id = Guid.Parse("3457b59a-8393-4d6d-b80f-08d471fcfe94"),
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
                    Id = Guid.Parse("49db4761-2849-4877-a4a5-05df5a94700e"),
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
                    Id = Guid.Parse("5ccd8183-2055-40bb-bd2f-5f75f09521e9"),
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
                    Id = Guid.Parse("19f2b08f-953f-4726-8406-f2df5f3ccfab"),
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
                    Id = Guid.Parse("8417ad24-60cd-45d3-bfc8-c5503d544361"),
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
                    Id = Guid.Parse("f0435b87-ff3b-4cca-af13-f12e0b6a01eb"),
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
                    Id = Guid.Parse("24f78ede-17ac-4851-a123-89d68ac6653e"),
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
                    Id = Guid.Parse("258909b8-0a3a-40b9-ac3a-6949d29f02f5"),
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
                    Id = Guid.Parse("aec3888f-733b-43c3-8e0b-626b187dee5d"),
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
                    Id = Guid.Parse("1fe6c1e4-2556-4cb3-ba89-5772044fff00"),
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
                    Id = Guid.Parse("68de397d-1790-4e81-ab59-84540ac236f9"),
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
                    Id = Guid.Parse("fa7a6506-2085-4d01-9182-a49e98b576c7"),
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
                    Id = Guid.Parse("3cbb83f0-81a8-4d20-bfd2-73a299d0099b"),
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
                    Id = Guid.Parse("6f4757c6-e5ee-4560-a659-1246b05e49ee"),
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
                    Id = Guid.Parse("539dab57-92ec-4899-9e3b-dfdf97295edc"),
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
                    Id = Guid.Parse("3a90db90-008e-4a70-8421-5d1461558bc9"),
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
                    Id = Guid.Parse("995f9627-2d72-4ac7-b478-10807a1145f1"),
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
                    Id = Guid.Parse("f74653ea-0c60-4a4d-b798-f5d780ff562e"),
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
                    Id = Guid.Parse("d0ba924f-2939-40fa-ae29-f611309f9f0a"),
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
                    Id = Guid.Parse("0a2250ba-fd8f-4231-8663-3ae38f96cbc7"),
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
                    Id = Guid.Parse("85b7e6a3-54a3-4530-80a8-b91aa1b5b166"),
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
                    Id = Guid.Parse("e3f774bc-8018-4aef-922d-b74bb43cc6cd"),
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
                    Id = Guid.Parse("a034c70b-5dcb-4e27-9acd-5f2d7134a06c"),
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
                    Id = Guid.Parse("12f3e458-05e4-4f30-9c19-2ac67fbcc4d7"),
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
                    Id = Guid.Parse("e8060642-8ceb-42b6-95af-d851c0f220b2"),
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
                    Id = Guid.Parse("7e46edaa-6e3a-46f8-9056-ccaee1774c6c"),
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
                    Id = Guid.Parse("4d2554c9-1f25-4243-aef0-318ce220efbc"),
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
                    Id = Guid.Parse("f7fecf7c-38f1-4864-be64-cafd57e1c715"),
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
                    Id = Guid.Parse("8cb114c8-6038-4f83-8041-0dd3ac6af293"),
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
                    Id = Guid.Parse("9b452ea7-95b7-40c6-9b77-0cf0daad83ce"),
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
                    Id = Guid.Parse("ed18eeab-318b-42b7-9754-05c18bca3318"),
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
                    Id = Guid.Parse("2687a4ec-a2ba-4e9a-a7ae-821fc4c98de4"),
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
                    Id = Guid.Parse("d5604c3f-3391-4198-af48-56160482d42d"),
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
                    Id = Guid.Parse("aa6607cc-70df-40e0-921b-b65354175778"),
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
                    Id = Guid.Parse("ae635af1-16f3-4e4d-91be-ffbaf359a4f8"),
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
                    Id = Guid.Parse("a916a6e8-fe05-4d6f-b0e4-967c07d74ff6"),
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
