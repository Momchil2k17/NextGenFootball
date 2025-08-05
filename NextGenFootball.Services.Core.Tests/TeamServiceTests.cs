using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Player;
using NextGenFootball.Web.ViewModels.Team;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class TeamServiceTests
{
    private Mock<ITeamRepository> teamRepositoryMock;
    private Mock<IStadiumRepository> stadiumRepositoryMock;
    private Mock<ILeagueRepository> leagueRepositoryMock;
    private Mock<IPlayerRepository> playerRepositoryMock;
    private ITeamService teamService;

    [SetUp]
    public void Setup()
    {
        teamRepositoryMock = new Mock<ITeamRepository>(MockBehavior.Strict);
        stadiumRepositoryMock = new Mock<IStadiumRepository>(MockBehavior.Strict);
        leagueRepositoryMock = new Mock<ILeagueRepository>(MockBehavior.Strict);
        playerRepositoryMock = new Mock<IPlayerRepository>(MockBehavior.Strict);

        teamService = new TeamService(
            teamRepositoryMock.Object,
            stadiumRepositoryMock.Object,
            leagueRepositoryMock.Object,
            playerRepositoryMock.Object);
    }

    [Test]
    public async Task CreateTeamAsync_ReturnsFalseIfRegionInvalidOrStadiumOrLeagueNull()
    {
        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync((Stadium)null);
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync((League)null);

        var model = new TeamCreateViewModel
        {
            Name = "Test",
            Region = (Region)999,
            AgeGroup = "U16",
            ImageUrl = "/img.png",
            Description = "desc",
            StadiumId = 1,
            LeagueId = 1
        };

        var result = await teamService.CreateTeamAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task CreateTeamAsync_AddsTeamAndReturnsTrue()
    {
        var stadium = new Stadium { Id = 1, Name = "StadiumA" };
        var league = new League { Id = 2, Name = "LeagueA" };
        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync(stadium);
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync(league);
        teamRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Team>())).Returns(Task.FromResult(true)).Verifiable();

        var model = new TeamCreateViewModel
        {
            Name = "Test",
            Region = Region.СевероизточнаБългария,
            AgeGroup = "U16",
            ImageUrl = "/img.png",
            Description = "desc",
            StadiumId = stadium.Id,
            LeagueId = league.Id
        };

        var result = await teamService.CreateTeamAsync(model);

        Assert.That(result, Is.True);
        teamRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Team>()), Times.Once);
    }

    [Test]
    public async Task GetAllTeamsAsync_ReturnsMappedTeams()
    {
        var stadium = new Stadium { Id = 1, Name = "StadiumA" };
        var league = new League { Id = 2, Name = "LeagueA" };
        var teams = new List<Team>
        {
            new Team { Id = 1, Name = "TeamA", Region = Region.СевероизточнаБългария, Stadium = stadium, League = league, ImageUrl = "/img1.png" },
            new Team { Id = 2, Name = "TeamB", Region = Region.ЮгоизточнаБългария, Stadium = stadium, League = league, ImageUrl = "/img2.png" }
        };

        var mockQueryable = teams.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await teamService.GetAllTeamsAsync();

        Assert.That(result.Count(), Is.EqualTo(teams.Count));
        Assert.That(result.Any(t => t.Name == "TeamA"), Is.True);
        Assert.That(result.Any(t => t.Name == "TeamB"), Is.True);
    }

    [Test]
    public async Task GetTeamDetailsAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await teamService.GetTeamDetailsAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<Team>().BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await teamService.GetTeamDetailsAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetTeamDetailsAsync_ReturnsDetailsIfFound()
    {
        var stadium = new Stadium { Id = 1, Name = "StadiumA" };
        var league = new League { Id = 2, Name = "LeagueA" };
        var team = new Team
        {
            Id = 5,
            Name = "TeamA",
            Region = Region.СеверозападнаБългария,
            Stadium = stadium,
            League = league,
            ImageUrl = "/img.png",
            Description = "desc"
        };

        var mockTeamQueryable = new List<Team> { team }.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockTeamQueryable);

        var goalkeepers = new List<Player>
        {
            new Player { Id = Guid.NewGuid(), TeamId = team.Id, IsDeleted = false, PositionEnum = PositionEnum.Goalkeeper, FirstName = "GK", LastName = "One", Position = "Goalkeeper", ImageUrl = "/gk1.png" }
        }.BuildMock();
        var defenders = new List<Player>
        {
            new Player { Id = Guid.NewGuid(), TeamId = team.Id, IsDeleted = false, PositionEnum = PositionEnum.Defender, FirstName = "Def", LastName = "One", Position = "Defender", ImageUrl = "/def1.png" }
        }.BuildMock();
        var midfielders = new List<Player>
        {
            new Player { Id = Guid.NewGuid(), TeamId = team.Id, IsDeleted = false, PositionEnum = PositionEnum.Midfielder, FirstName = "Mid", LastName = "One", Position = "Midfielder", ImageUrl = "/mid1.png" }
        }.BuildMock();
        var forwards = new List<Player>
        {
            new Player { Id = Guid.NewGuid(), TeamId = team.Id, IsDeleted = false, PositionEnum = PositionEnum.Forward, FirstName = "For", LastName = "One", Position = "Forward", ImageUrl = "/for1.png" }
        }.BuildMock();

        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(goalkeepers);
        await teamService.GetTeamDetailsAsync(team.Id);
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(defenders);
        await teamService.GetTeamDetailsAsync(team.Id);
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(midfielders);
        await teamService.GetTeamDetailsAsync(team.Id);
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(forwards);

        var result = await teamService.GetTeamDetailsAsync(team.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(team.Id));
        Assert.That(result.Name, Is.EqualTo(team.Name));
        Assert.That(result.Region, Is.EqualTo(TeamService.GetDisplayName(team.Region)));
        Assert.That(result.Stadium, Is.EqualTo(stadium.Name));
        Assert.That(result.League, Is.EqualTo(league.Name));
    }

    [Test]
    public async Task GetTeamForEditAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await teamService.GetTeamForEditAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<Team>().BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await teamService.GetTeamForEditAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetTeamForEditAsync_ReturnsEditViewModelIfFound()
    {
        var stadium = new Stadium { Id = 1, Name = "StadiumA" };
        var league = new League { Id = 2, Name = "LeagueA" };
        var team = new Team
        {
            Id = 5,
            Name = "TeamA",
            Region = Region.СеверозападнаБългария,
            AgeGroup = "U16",
            Stadium = stadium,
            League = league,
            ImageUrl = "/img.png",
            Description = "desc",
            StadiumId = stadium.Id,
            LeagueId = league.Id
        };

        var mockQueryable = new List<Team> { team }.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await teamService.GetTeamForEditAsync(team.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(team.Id));
        Assert.That(result.Name, Is.EqualTo(team.Name));
        Assert.That(result.Region, Is.EqualTo(team.Region));
        Assert.That(result.AgeGroup, Is.EqualTo(team.AgeGroup));
        Assert.That(result.StadiumId, Is.EqualTo(stadium.Id));
        Assert.That(result.LeagueId, Is.EqualTo(league.Id));
    }

    [Test]
    public async Task EditTeamAsync_ReturnsFalseIfRegionInvalidOrStadiumOrLeagueNullOrTeamNotFound()
    {
        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync((Stadium)null);
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync((League)null);

        var model = new TeamEditViewModel
        {
            Id = 5,
            Name = "TeamA",
            Region = (Region)999,
            AgeGroup = "U16",
            ImageUrl = "/img.png",
            Description = "desc",
            StadiumId = 1,
            LeagueId = 2
        };

        var result = await teamService.EditTeamAsync(model);
        Assert.That(result, Is.False);

        model.Region = Region.СевероизточнаБългария;
        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync(new Stadium { Id = 1 });
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync(new League { Id = 2 });
        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync((Team)null);

        result = await teamService.EditTeamAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task EditTeamAsync_UpdatesTeamAndReturnsTrue()
    {
        var stadium = new Stadium { Id = 1 };
        var league = new League { Id = 2 };
        var team = new Team { Id = 5, Name = "Old Name", Region = Region.СевероизточнаБългария, AgeGroup = "Old Group", StadiumId = stadium.Id, LeagueId = league.Id, ImageUrl = "/oldimg.png", Description = "Old Desc" };

        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync(stadium);
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync(league);
        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync(team);
        teamRepositoryMock.Setup(r => r.UpdateAsync(team)).Returns(Task.FromResult(true)).Verifiable();

        var model = new TeamEditViewModel
        {
            Id = team.Id,
            Name = "New Name",
            Region = Region.ЮгозападнаБългария,
            AgeGroup = "U18",
            ImageUrl = "/newimg.png",
            Description = "New Desc",
            StadiumId = stadium.Id,
            LeagueId = league.Id
        };

        var result = await teamService.EditTeamAsync(model);

        Assert.That(result, Is.True);
        teamRepositoryMock.Verify(r => r.UpdateAsync(team), Times.Once);
        Assert.That(team.Name, Is.EqualTo(model.Name));
        Assert.That(team.Region, Is.EqualTo(model.Region));
        Assert.That(team.AgeGroup, Is.EqualTo(model.AgeGroup));
        Assert.That(team.ImageUrl, Is.EqualTo(model.ImageUrl));
        Assert.That(team.Description, Is.EqualTo(model.Description));
        Assert.That(team.StadiumId, Is.EqualTo(model.StadiumId));
        Assert.That(team.LeagueId, Is.EqualTo(model.LeagueId));
    }

    [Test]
    public async Task GetTeamForDeleteAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await teamService.GetTeamForDeleteAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<Team>().BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await teamService.GetTeamForDeleteAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetTeamForDeleteAsync_ReturnsDeleteViewModelIfFound()
    {
        var league = new League { Id = 2, Name = "LeagueA" };
        var team = new Team
        {
            Id = 5,
            Name = "TeamA",
            AgeGroup = "U16",
            League = league,
            LeagueId = league.Id
        };

        var mockQueryable = new List<Team> { team }.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await teamService.GetTeamForDeleteAsync(team.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(team.Id));
        Assert.That(result.Name, Is.EqualTo(team.Name));
        Assert.That(result.AgeGroup, Is.EqualTo(team.AgeGroup));
        Assert.That(result.LeagueName, Is.EqualTo(league.Name));
    }

    [Test]
    public async Task DeleteTeamAsync_ReturnsFalseIfNotFound()
    {
        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync((Team)null);

        var model = new TeamDeleteViewModel { Id = 99 };

        var result = await teamService.DeleteTeamAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DeleteTeamAsync_DeletesTeamAndReturnsTrue()
    {
        var team = new Team { Id = 5 };

        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Team, bool>>>())).ReturnsAsync(team);
        teamRepositoryMock.Setup(r => r.DeleteAsync(team)).Returns(Task.FromResult(true)).Verifiable();

        var model = new TeamDeleteViewModel { Id = team.Id };
        var result = await teamService.DeleteTeamAsync(model);

        Assert.That(result, Is.True);
        teamRepositoryMock.Verify(r => r.DeleteAsync(team), Times.Once);
    }

    [Test]
    public async Task GetTeamDropdownViewModelsAsync_ReturnsDropdownModels()
    {
        var teams = new List<Team>
        {
            new Team { Id = 1, Name = "TeamA", IsDeleted = false },
            new Team { Id = 2, Name = "TeamB", IsDeleted = false }
        };

        var mockQueryable = teams.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await teamService.GetTeamDropdownViewModelsAsync();

        Assert.That(result.Count(), Is.EqualTo(teams.Count));
        Assert.That(result.Any(t => t.Name == "TeamA"), Is.True);
        Assert.That(result.Any(t => t.Name == "TeamB"), Is.True);
    }

    [Test]
    public async Task GetTeamDropdownViewModelsByLeagueAsync_ReturnsDropdownModels()
    {
        int leagueId = 2;
        var teams = new List<Team>
        {
            new Team { Id = 1, Name = "TeamA", IsDeleted = false, LeagueId = leagueId },
            new Team { Id = 2, Name = "TeamB", IsDeleted = false, LeagueId = leagueId }
        };

        var mockQueryable = teams.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await teamService.GetTeamDropdownViewModelsByLeagueAsync(leagueId);

        Assert.That(result.Count(), Is.EqualTo(teams.Count));
        Assert.That(result.All(t => t.Id == 1 || t.Id == 2), Is.True);
    }
}