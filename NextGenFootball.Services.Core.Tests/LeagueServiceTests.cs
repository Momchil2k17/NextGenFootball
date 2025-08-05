using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;
using NextGenFootball.Web.ViewModels.Player;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class LeagueServiceTests
{
    private Mock<ILeagueRepository> leagueRepositoryMock;
    private Mock<ISeasonRepository> seasonRepositoryMock;
    private Mock<IPlayerRepository> playerRepositoryMock;
    private ILeagueService leagueService;

    [SetUp]
    public void Setup()
    {
        leagueRepositoryMock = new Mock<ILeagueRepository>(MockBehavior.Strict);
        seasonRepositoryMock = new Mock<ISeasonRepository>(MockBehavior.Strict);
        playerRepositoryMock = new Mock<IPlayerRepository>(MockBehavior.Strict);

        leagueService = new LeagueService(
            leagueRepositoryMock.Object,
            seasonRepositoryMock.Object,
            playerRepositoryMock.Object);
    }

    [Test]
    public async Task CreateLeagueAsync_ReturnsFalseIfRegionInvalidOrSeasonNull()
    {
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync((Season)null);

        var model = new LeagueCreateViewModel
        {
            Name = "Test",
            Region = (Region)999,
            AgeGroup = "U16",
            Description = "desc",
            ImageUrl = "/img.png",
            SeasonId = 1
        };

        var result = await leagueService.CreateLeagueAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task CreateLeagueAsync_AddsLeagueAndReturnsTrue()
    {
        var season = new Season { Id = 1, Name = "2025/2026" };
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync(season);
        leagueRepositoryMock.Setup(r => r.AddAsync(It.IsAny<League>())).Returns(Task.FromResult(true)).Verifiable();

        var model = new LeagueCreateViewModel
        {
            Name = "Test",
            Region = Region.СевероизточнаБългария,
            AgeGroup = "U16",
            Description = "desc",
            ImageUrl = "/img.png",
            SeasonId = season.Id
        };

        var result = await leagueService.CreateLeagueAsync(model);

        Assert.That(result, Is.True);
        leagueRepositoryMock.Verify(r => r.AddAsync(It.IsAny<League>()), Times.Once);
    }

    [Test]
    public async Task GetAllLeaguesAsync_ReturnsMappedLeagues()
    {
        var season = new Season { Id = 1, Name = "2025/2026" };
        var leagues = new List<League>
        {
            new League { Id = 1, Name = "LeagueA", Region = Region.СевероизточнаБългария, AgeGroup = "U16", Season = season, ImageUrl = "/img1.png", IsDeleted = false },
            new League { Id = 2, Name = "LeagueB", Region = Region.България, AgeGroup = "U18", Season = season, ImageUrl = "/img2.png", IsDeleted = false }
        };

        var mockQueryable = leagues.BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await leagueService.GetAllLeaguesAsync();

        Assert.That(result.Count(), Is.EqualTo(leagues.Count));
        Assert.That(result.Any(l => l.Name == "LeagueA"), Is.True);
        Assert.That(result.Any(l => l.Name == "LeagueB"), Is.True);
        Assert.That(result.First(l => l.Id == 1).Region, Is.EqualTo(LeagueService.GetDisplayName(Region.СевероизточнаБългария)));
    }

    [Test]
    public async Task GetLeagueDetailsAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await leagueService.GetLeagueDetailsAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<League>().BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await leagueService.GetLeagueDetailsAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetLeagueDetailsAsync_ReturnsDetailsIfFound()
    {
        var season = new Season { Id = 1, Name = "2025/2026" };
        var team = new Team { Id = 1, Name = "TeamA", ImageUrl = "/teamA.png", LeagueId = 1 };
        var match = new NextGenFootball.Data.Models.Match
        {
            Id = 10,
            HomeTeamId = team.Id,
            HomeTeam = team,
            AwayTeamId = team.Id,
            AwayTeam = team,
            Date = DateTime.Now.AddDays(1),
            HomeScore = 2,
            AwayScore = 1,
            Status = MatchStatus.Scheduled,
            IsDeleted = false,
            Round = 1
        };
        var league = new League
        {
            Id = 1,
            Name = "LeagueA",
            Region = Region.СевероизточнаБългария,
            AgeGroup = "U16",
            Season = season,
            SeasonId = season.Id,
            ImageUrl = "/img.png",
            Description = "desc",
            Teams = new List<Team> { team },
            Matches = new List<NextGenFootball.Data.Models.Match> { match }
        };

        var mockLeagueQueryable = new List<League> { league }.BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockLeagueQueryable);

        var players = new List<Player>
        {
            new Player { Id = Guid.NewGuid(), TeamId = team.Id, Team = team, Goals = 11, FirstName = "Top", LastName = "Scorer", ImageUrl = "/player.png" }
        }.BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(players);

        var result = await leagueService.GetLeagueDetailsAsync(league.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(league.Id));
        Assert.That(result.Name, Is.EqualTo(league.Name));
        Assert.That(result.Region, Is.EqualTo(LeagueService.GetDisplayName(league.Region)));
        Assert.That(result.SeasonName, Is.EqualTo(season.Name));
        Assert.That(result.TopGoalscorers.Count(), Is.EqualTo(1));
        Assert.That(result.TopGoalscorers.First().PlayerName, Is.EqualTo("Top Scorer"));
    }

    [Test]
    public async Task GetLeagueForEditAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await leagueService.GetLeagueForEditAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<League>().BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await leagueService.GetLeagueForEditAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetLeagueForEditAsync_ReturnsEditViewModelIfFound()
    {
        var season = new Season { Id = 1, Name = "2025/2026" };
        var league = new League
        {
            Id = 1,
            Name = "LeagueA",
            Region = Region.СевероизточнаБългария,
            AgeGroup = "U16",
            Season = season,
            SeasonId = season.Id,
            ImageUrl = "/img.png",
            Description = "desc"
        };

        var mockQueryable = new List<League> { league }.BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await leagueService.GetLeagueForEditAsync(league.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(league.Id));
        Assert.That(result.Name, Is.EqualTo(league.Name));
        Assert.That(result.Region, Is.EqualTo(league.Region));
        Assert.That(result.SeasonId, Is.EqualTo(season.Id));
    }

    [Test]
    public async Task EditLeagueAsync_ReturnsFalseIfRegionInvalidOrSeasonNullOrLeagueNotFound()
    {
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync((Season)null);

        var model = new LeagueEditViewModel
        {
            Id = 1,
            Name = "LeagueA",
            Region = (Region)999,
            AgeGroup = "U16",
            Description = "desc",
            ImageUrl = "/img.png",
            SeasonId = 1
        };

        var result = await leagueService.EditLeagueAsync(model);
        Assert.That(result, Is.False);

        model.Region = Region.СевероизточнаБългария;
        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync(new Season { Id = 1 });
        var mockQueryable = new List<League>().BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await leagueService.EditLeagueAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task EditLeagueAsync_UpdatesLeagueAndReturnsTrue()
    {
        var season = new Season { Id = 1 };
        var league = new League
        {
            Id = 1,
            Name = "Old Name",
            Region = Region.СевероизточнаБългария,
            AgeGroup = "Old Group",
            SeasonId = season.Id,
            ImageUrl = "/oldimg.png",
            Description = "Old Desc"
        };

        seasonRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>())).ReturnsAsync(season);
        var mockQueryable = new List<League> { league }.BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);
        leagueRepositoryMock.Setup(r => r.UpdateAsync(league)).Returns(Task.FromResult(true)).Verifiable();

        var model = new LeagueEditViewModel
        {
            Id = league.Id,
            Name = "New Name",
            Region = Region.България,
            AgeGroup = "U18",
            Description = "New Desc",
            ImageUrl = "/newimg.png",
            SeasonId = season.Id
        };

        var result = await leagueService.EditLeagueAsync(model);

        Assert.That(result, Is.True);
        leagueRepositoryMock.Verify(r => r.UpdateAsync(league), Times.Once);
        Assert.That(league.Name, Is.EqualTo(model.Name));
        Assert.That(league.Region, Is.EqualTo(model.Region));
        Assert.That(league.AgeGroup, Is.EqualTo(model.AgeGroup));
        Assert.That(league.ImageUrl, Is.EqualTo(model.ImageUrl));
        Assert.That(league.Description, Is.EqualTo(model.Description));
        Assert.That(league.SeasonId, Is.EqualTo(model.SeasonId));
    }

    [Test]
    public async Task GetLeagueForDeleteAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await leagueService.GetLeagueForDeleteAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<League>().BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await leagueService.GetLeagueForDeleteAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetLeagueForDeleteAsync_ReturnsDeleteViewModelIfFound()
    {
        var season = new Season { Id = 1, Name = "2025/2026" };
        var league = new League
        {
            Id = 1,
            Name = "LeagueA",
            Region = Region.България,
            AgeGroup = "U16",
            Season = season,
            ImageUrl = "/img.png",
            Description = "desc"
        };

        var mockQueryable = new List<League> { league }.BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await leagueService.GetLeagueForDeleteAsync(league.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(league.Id));
        Assert.That(result.Name, Is.EqualTo(league.Name));
        Assert.That(result.Region, Is.EqualTo(LeagueService.GetDisplayName(league.Region)));
        Assert.That(result.SeasonName, Is.EqualTo(season.Name));
    }

    [Test]
    public async Task DeleteLeagueAsync_ReturnsFalseIfNotFound()
    {
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync((League)null);

        var model = new LeagueDetailsViewModel { Id = 99 };

        var result = await leagueService.DeleteLeagueAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DeleteLeagueAsync_DeletesLeagueAndReturnsTrue()
    {
        var league = new League { Id = 1 };

        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync(league);
        leagueRepositoryMock.Setup(r => r.DeleteAsync(league)).Returns(Task.FromResult(true)).Verifiable();

        var model = new LeagueDetailsViewModel { Id = league.Id };
        var result = await leagueService.DeleteLeagueAsync(model);

        Assert.That(result, Is.True);
        leagueRepositoryMock.Verify(r => r.DeleteAsync(league), Times.Once);
    }

    [Test]
    public async Task GetLeaguesForDropdownAsync_ReturnsDropdownModels()
    {
        var leagues = new List<League>
        {
            new League { Id = 1, Name = "LeagueA" },
            new League { Id = 2, Name = "LeagueB" }
        };

        var mockQueryable = leagues.BuildMock();
        leagueRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await leagueService.GetLeaguesForDropdownAsync();

        Assert.That(result.Count(), Is.EqualTo(leagues.Count));
        Assert.That(result.Any(l => l.Name == "LeagueA"), Is.True);
        Assert.That(result.Any(l => l.Name == "LeagueB"), Is.True);
    }
}