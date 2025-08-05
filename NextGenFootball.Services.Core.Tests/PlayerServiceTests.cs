using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Player;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class PlayerServiceTests
{
    private Mock<IPlayerRepository> playerRepositoryMock;
    private Mock<ITeamRepository> teamRepositoryMock;
    private Mock<ISeasonRepository> seasonRepositoryMock;
    private Mock<IApplicationUserRepository> applicationUserRepositoryMock;
    private Mock<ICoachRepository> coachRepositoryMock;
    private IPlayerService playerService;

    [SetUp]
    public void Setup()
    {
        playerRepositoryMock = new Mock<IPlayerRepository>(MockBehavior.Strict);
        teamRepositoryMock = new Mock<ITeamRepository>(MockBehavior.Strict);
        seasonRepositoryMock = new Mock<ISeasonRepository>(MockBehavior.Strict);
        applicationUserRepositoryMock = new Mock<IApplicationUserRepository>(MockBehavior.Strict);
        coachRepositoryMock = new Mock<ICoachRepository>(MockBehavior.Strict);

        playerService = new PlayerService(
            playerRepositoryMock.Object,
            teamRepositoryMock.Object,
            seasonRepositoryMock.Object,
            applicationUserRepositoryMock.Object,
            coachRepositoryMock.Object);
    }
    [Test]
    public void AlwaysPass()
    {
        Assert.Pass();
    }

    [Test]
    public async Task CreatePlayerAsync_ReturnsFalseIfTeamOrSeasonIsNull()
    {
        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync((Team)null);
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync((Season)null);

        var model = new PlayerCreateViewModel
        {
            TeamId = 1,
            SeasonId = 1,
            PreferredFoot = PreferredFoot.Right,
            PositionEnum = PositionEnum.Forward,
            FirstName = "Test",
            LastName = "Player",
            DateOfBirth = DateTime.Today,
            Position = "Forward"
        };

        var result = await playerService.CreatePlayerAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task CreatePlayerAsync_ReturnsFalseIfEnumsAreInvalid()
    {
        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync(new Team());
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync(new Season());

        var model = new PlayerCreateViewModel
        {
            TeamId = 1,
            SeasonId = 1,
            PreferredFoot = (PreferredFoot)999,
            PositionEnum = (PositionEnum)999,
            FirstName = "Test",
            LastName = "Player",
            DateOfBirth = DateTime.Today,
            Position = "Forward"
        };

        var result = await playerService.CreatePlayerAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task CreatePlayerAsync_AddsPlayerAndReturnsTrue()
    {
        var team = new Team { Id = 1, Name = "TeamA" };
        var season = new Season { Id = 1, Name = "SeasonA" };

        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync(team);
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync(season);
        playerRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Player>())).Returns(Task.FromResult(true)).Verifiable();

        var model = new PlayerCreateViewModel
        {
            TeamId = team.Id,
            SeasonId = season.Id,
            PreferredFoot = PreferredFoot.Right,
            PositionEnum = PositionEnum.Forward,
            FirstName = "Test",
            LastName = "Player",
            DateOfBirth = DateTime.Today,
            Position = "Forward"
        };

        var result = await playerService.CreatePlayerAsync(model);

        Assert.That(result, Is.True);
        playerRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Player>()), Times.Once);
    }

    [Test]
    public async Task GetAllPlayersAsync_ReturnsMappedPlayers()
    {
        var team = new Team { Id = 1, Name = "TeamA", ImageUrl = "/images/teamA.png" };
        var season = new Season { Id = 1, Name = "SeasonA" };
        var players = new List<Player>
        {
            new Player { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Team = team, Season = season, PreferredFoot = PreferredFoot.Right, Position = "Forward", DateOfBirth = DateTime.Today, ImageUrl = null, TeamId = team.Id, SeasonId = season.Id },
            new Player { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Team = team, Season = season, PreferredFoot = PreferredFoot.Left, Position = "Midfielder", DateOfBirth = DateTime.Today.AddYears(-2), ImageUrl = "/img.jpg", TeamId = team.Id, SeasonId = season.Id }
        };

        var mockQueryable = players.BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await playerService.GetAllPlayersAsync();

        Assert.That(result.Count(), Is.EqualTo(players.Count));
        Assert.That(result.Any(p => p.FirstName == "John"), Is.True);
        Assert.That(result.Any(p => p.FirstName == "Jane"), Is.True);
    }

    [Test]
    public async Task GetPlayerDetailsAsync_ReturnsNullIfIdIsInvalid()
    {
        var result = await playerService.GetPlayerDetailsAsync(null);
        Assert.That(result, Is.Null);

        result = await playerService.GetPlayerDetailsAsync(Guid.Empty);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetPlayerDetailsAsync_ReturnsNullIfPlayerNotFound()
    {
        var mockQueryable = new List<Player>().BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await playerService.GetPlayerDetailsAsync(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetPlayerDetailsAsync_ReturnsDetailsIfPlayerFound()
    {
        var team = new Team { Id = 1, Name = "TeamA", ImageUrl = "/images/teamA.png" };
        var season = new Season { Id = 1, Name = "SeasonA" };
        var playerId = Guid.NewGuid();
        var player = new Player
        {
            Id = playerId,
            FirstName = "John",
            LastName = "Doe",
            Team = team,
            Season = season,
            PreferredFoot = PreferredFoot.Right,
            Position = "Forward",
            DateOfBirth = DateTime.Today,
            ImageUrl = null,
            Goals = 10,
            Assists = 5,
            MinutesPlayed = 900,
            YellowCards = 2,
            RedCards = 1,
            TeamId = team.Id,
            SeasonId = season.Id
        };

        var mockQueryable = new List<Player> { player }.BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await playerService.GetPlayerDetailsAsync(playerId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(player.Id));
        Assert.That(result.TeamName, Is.EqualTo(team.Name));
        Assert.That(result.Goals, Is.EqualTo(player.Goals));
    }

    [Test]
    public async Task GetPlayerForEditAsync_ReturnsNullIfIdIsInvalid()
    {
        var result = await playerService.GetPlayerForEditAsync(null);
        Assert.That(result, Is.Null);

        result = await playerService.GetPlayerForEditAsync(Guid.Empty);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetPlayerForEditAsync_ReturnsNullIfPlayerNotFound()
    {
        var mockQueryable = new List<Player>().BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await playerService.GetPlayerForEditAsync(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetPlayerForEditAsync_ReturnsEditViewModelIfPlayerFound()
    {
        var team = new Team { Id = 1, Name = "TeamA" };
        var season = new Season { Id = 1, Name = "SeasonA" };
        var playerId = Guid.NewGuid();
        var player = new Player
        {
            Id = playerId,
            FirstName = "John",
            LastName = "Doe",
            Team = team,
            Season = season,
            PreferredFoot = PreferredFoot.Right,
            Position = "Forward",
            DateOfBirth = DateTime.Today,
            ImageUrl = null,
            PositionEnum = PositionEnum.Forward,
            TeamId = team.Id,
            SeasonId = season.Id
        };

        var mockQueryable = new List<Player> { player }.BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await playerService.GetPlayerForEditAsync(playerId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(player.Id));
        Assert.That(result.FirstName, Is.EqualTo(player.FirstName));
        Assert.That(result.TeamId, Is.EqualTo(team.Id));
        Assert.That(result.SeasonId, Is.EqualTo(season.Id));
    }

    [Test]
    public async Task UpdatePlayerAsync_ReturnsFalseIfTeamOrSeasonIsNullOrEnumInvalid()
    {
        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync((Team)null);
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync((Season)null);
        applicationUserRepositoryMock
        .Setup(r => r.ExistsByIdAsync(It.IsAny<Guid?>()))
        .ReturnsAsync(false);
        var model = new PlayerEditViewModel
        {
            TeamId = 1,
            SeasonId = 1,
            PreferredFoot = (PreferredFoot)999,
            PositionEnum = (PositionEnum)999,
            ApplicationUserId = Guid.NewGuid(),
            Id = Guid.NewGuid(),
            FirstName = "Test",
            LastName = "Player",
            DateOfBirth = DateTime.Today,
            Position = "Forward"
        };

        var result = await playerService.UpdatePlayerAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task UpdatePlayerAsync_UpdatesPlayerAndReturnsTrue()
    {
        var team = new Team { Id = 1 };
        var season = new Season { Id = 1 };
        var playerId = Guid.NewGuid();
        var player = new Player
        {
            Id = playerId,
            TeamId = team.Id,
            SeasonId = season.Id,
            ApplicationUserId = null
        };

        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync(team);
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync(season);
        applicationUserRepositoryMock.Setup(r => r.ExistsByIdAsync(It.IsAny<Guid?>())).ReturnsAsync(true);

        var mockQueryable = new List<Player> { player }.BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);
        playerRepositoryMock.Setup(r => r.UpdateAsync(player)).Returns(Task.FromResult(true)).Verifiable();

        var model = new PlayerEditViewModel
        {
            TeamId = team.Id,
            SeasonId = season.Id,
            PreferredFoot = PreferredFoot.Right,
            PositionEnum = PositionEnum.Forward,
            ApplicationUserId = Guid.NewGuid(),
            Id = playerId,
            FirstName = "Test",
            LastName = "Player",
            DateOfBirth = DateTime.Today,
            Position = "Forward"
        };

        var result = await playerService.UpdatePlayerAsync(model);

        Assert.That(result, Is.True);
        playerRepositoryMock.Verify(r => r.UpdateAsync(player), Times.Once);
        Assert.That(player.FirstName, Is.EqualTo(model.FirstName));
    }

    [Test]
    public async Task GetPlayerStatsForEditAsync_ReturnsNullIfIdIsInvalidOrNotFound()
    {
        var result = await playerService.GetPlayerStatsForEditAsync(null);
        Assert.That(result, Is.Null);

        result = await playerService.GetPlayerStatsForEditAsync(Guid.Empty);
        Assert.That(result, Is.Null);

        playerRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Player, bool>>>())).ReturnsAsync((Player)null);
        result = await playerService.GetPlayerStatsForEditAsync(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetPlayerStatsForEditAsync_ReturnsStatsViewModelIfPlayerFound()
    {
        var playerId = Guid.NewGuid();
        var player = new Player
        {
            Id = playerId,
            FirstName = "John",
            LastName = "Doe",
            Goals = 10,
            MinutesPlayed = 900,
            RedCards = 1,
            YellowCards = 2,
            Assists = 5
        };

        playerRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Player, bool>>>())).ReturnsAsync(player);

        var result = await playerService.GetPlayerStatsForEditAsync(playerId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(playerId));
        Assert.That(result.Goals, Is.EqualTo(player.Goals));
    }

    [Test]
    public async Task UpdatePlayerStatsAsync_ReturnsFalseIfPlayerNotFound()
    {
        playerRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Player, bool>>>())).ReturnsAsync((Player)null);

        var model = new PlayerStatsEditViewModel
        {
            Id = Guid.NewGuid(),
            Goals = 5,
            MinutesPlayed = 500,
            RedCards = 0,
            YellowCards = 1,
            Assists = 3
        };

        var result = await playerService.UpdatePlayerStatsAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task UpdatePlayerStatsAsync_UpdatesStatsAndReturnsTrue()
    {
        var playerId = Guid.NewGuid();
        var player = new Player
        {
            Id = playerId
        };

        playerRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Player, bool>>>())).ReturnsAsync(player);
        playerRepositoryMock.Setup(r => r.UpdateAsync(player)).Returns(Task.FromResult(true)).Verifiable();

        var model = new PlayerStatsEditViewModel
        {
            Id = playerId,
            Goals = 5,
            MinutesPlayed = 500,
            RedCards = 0,
            YellowCards = 1,
            Assists = 3
        };

        var result = await playerService.UpdatePlayerStatsAsync(model);

        Assert.That(result, Is.True);
        playerRepositoryMock.Verify(r => r.UpdateAsync(player), Times.Once);
        Assert.That(player.Goals, Is.EqualTo(model.Goals));
    }

    [Test]
    public async Task GetPlayerForDeleteAsync_ReturnsNullIfIdIsInvalidOrNotFound()
    {
        var result = await playerService.GetPlayerForDeleteAsync(null);
        Assert.That(result, Is.Null);

        result = await playerService.GetPlayerForDeleteAsync(Guid.Empty);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<Player>().BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await playerService.GetPlayerForDeleteAsync(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetPlayerForDeleteAsync_ReturnsDeleteViewModelIfPlayerFound()
    {
        var team = new Team { Id = 1, Name = "TeamA" };
        var season = new Season { Id = 1, Name = "SeasonA" };
        var playerId = Guid.NewGuid();
        var player = new Player
        {
            Id = playerId,
            FirstName = "John",
            LastName = "Doe",
            Team = team,
            Season = season,
            TeamId = team.Id,
            SeasonId = season.Id
        };

        var mockQueryable = new List<Player> { player }.BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await playerService.GetPlayerForDeleteAsync(playerId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(playerId));
        Assert.That(result.TeamName, Is.EqualTo(team.Name));
    }

    [Test]
    public async Task DeletePlayerAsync_ReturnsFalseIfPlayerNotFound()
    {
        playerRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Player, bool>>>())).ReturnsAsync((Player)null);

        var model = new PlayerDeleteViewModel { Id = Guid.NewGuid() };
        var result = await playerService.DeletePlayerAsync(model);

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DeletePlayerAsync_DeletesPlayerAndReturnsTrue()
    {
        var playerId = Guid.NewGuid();
        var player = new Player { Id = playerId };

        playerRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Player, bool>>>())).ReturnsAsync(player);
        playerRepositoryMock.Setup(r => r.DeleteAsync(player)).Returns(Task.FromResult(true)).Verifiable();

        var model = new PlayerDeleteViewModel { Id = playerId };
        var result = await playerService.DeletePlayerAsync(model);

        Assert.That(result, Is.True);
        playerRepositoryMock.Verify(r => r.DeleteAsync(player), Times.Once);
    }
}