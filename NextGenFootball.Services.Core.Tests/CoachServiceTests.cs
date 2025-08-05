using Microsoft.AspNetCore.Identity;
using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;
using NextGenFootball.Web.ViewModels.Player;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class CoachServiceTests
{
    private Mock<ICoachRepository> coachRepositoryMock;
    private Mock<ITeamRepository> teamRepositoryMock;
    private Mock<IApplicationUserRepository> applicationUserRepositoryMock;
    private Mock<IPlayerRepository> playerRepositoryMock;
    private Mock<ITeamStartingLineupRepository> teamStartingLineupRepositoryMock;
    private Mock<ITeamStartingLineupPlayerRepository> teamStartingLineupPlayerRepositoryMock;
    private Mock<UserManager<ApplicationUser>> userManagerMock;

    private ICoachService coachService;

    [SetUp]
    public void Setup()
    {
        coachRepositoryMock = new Mock<ICoachRepository>(MockBehavior.Strict);
        teamRepositoryMock = new Mock<ITeamRepository>(MockBehavior.Strict);
        applicationUserRepositoryMock = new Mock<IApplicationUserRepository>(MockBehavior.Strict);
        playerRepositoryMock = new Mock<IPlayerRepository>(MockBehavior.Strict);
        teamStartingLineupRepositoryMock = new Mock<ITeamStartingLineupRepository>(MockBehavior.Strict);
        teamStartingLineupPlayerRepositoryMock = new Mock<ITeamStartingLineupPlayerRepository>(MockBehavior.Strict);
        userManagerMock = new Mock<UserManager<ApplicationUser>>(MockBehavior.Strict, null, null, null, null, null, null, null, null);

        coachService = new CoachService(
            coachRepositoryMock.Object,
            teamRepositoryMock.Object,
            applicationUserRepositoryMock.Object,
            playerRepositoryMock.Object,
            null,
            teamStartingLineupPlayerRepositoryMock.Object,
            teamStartingLineupRepositoryMock.Object
            );
    }

    [Test]
    public async Task GetAllCoachesAsync_ReturnsMappedCoaches()
    {
        var team = new Team { Id = 1, Name = "TeamA", ImageUrl = "/team.png" };
        var coaches = new List<Coach>
        {
            new Coach { Id = Guid.NewGuid(), FirstName = "John", LastName = "Smith", ImageUrl = "/img.png", Team = team, Role = CoachRole.HeadCoach }
        };
        var mockQueryable = coaches.BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await coachService.GetAllCoachesAsync();

        Assert.That(result.Count(), Is.EqualTo(coaches.Count));
        Assert.That(result.First().FirstName, Is.EqualTo("John"));
        Assert.That(result.First().TeamName, Is.EqualTo(team.Name));
        Assert.That(result.First().Role, Is.EqualTo(CoachService.GetDisplayName(CoachRole.HeadCoach)));
    }

    [Test]
    public async Task GetCoachDetailsAsync_ReturnsNullIfIdIsNullOrEmptyOrNotFound()
    {
        var result = await coachService.GetCoachDetailsAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<Coach>().BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await coachService.GetCoachDetailsAsync(Guid.Empty);
        Assert.That(result, Is.Null);

        result = await coachService.GetCoachDetailsAsync(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetCoachDetailsAsync_ReturnsDetailsIfFound()
    {
        var team = new Team { Id = 1, Name = "TeamA", ImageUrl = "/team.png" };
        var coachId = Guid.NewGuid();
        var coach = new Coach { Id = coachId, FirstName = "John", LastName = "Smith", ImageUrl = "/img.png", Team = team, Role = CoachRole.AssistantCoach };
        var mockQueryable = new List<Coach> { coach }.BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await coachService.GetCoachDetailsAsync(coachId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(coach.Id));
        Assert.That(result.FirstName, Is.EqualTo(coach.FirstName));
        Assert.That(result.TeamName, Is.EqualTo(team.Name));
        Assert.That(result.Role, Is.EqualTo(CoachService.GetDisplayName(CoachRole.AssistantCoach)));
    }

    [Test]
    public async Task CreateCoachAsync_ReturnsFalseIfRoleInvalidOrTeamNull()
    {
        var mockQueryable = new List<Team>().BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var model = new CoachCreateViewModel
        {
            FirstName = "Jane",
            LastName = "Doe",
            ImageUrl = "/img.png",
            TeamId = 1,
            Role = (CoachRole)999
        };

        var result = await coachService.CreateCoachAsync(model);
        Assert.That(result, Is.False);

        model.Role = CoachRole.HeadCoach;
        result = await coachService.CreateCoachAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task CreateCoachAsync_AddsCoachAndReturnsTrue()
    {
        var team = new Team { Id = 1, Name = "TeamA" };
        var mockQueryable = new List<Team> { team }.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);
        coachRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Coach>())).Returns(Task.FromResult(true)).Verifiable();

        var model = new CoachCreateViewModel
        {
            FirstName = "Jane",
            LastName = "Doe",
            ImageUrl = "/img.png",
            TeamId = team.Id,
            Role = CoachRole.HeadCoach
        };

        var result = await coachService.CreateCoachAsync(model);

        Assert.That(result, Is.True);
        coachRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Coach>()), Times.Once);
    }

    [Test]
    public async Task GetCoachEditViewModel_ReturnsNullIfIdIsNullOrEmptyOrNotFound()
    {
        var result = await coachService.GetCoachEditViewModel(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<Coach>().BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await coachService.GetCoachEditViewModel(Guid.Empty);
        Assert.That(result, Is.Null);

        result = await coachService.GetCoachEditViewModel(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetCoachEditViewModel_ReturnsEditViewModelIfFound()
    {
        var team = new Team { Id = 1, Name = "TeamA" };
        var coachId = Guid.NewGuid();
        var coach = new Coach
        {
            Id = coachId,
            FirstName = "Jane",
            LastName = "Doe",
            ImageUrl = "/img.png",
            Team = team,
            TeamId = team.Id,
            Role = CoachRole.HeadCoach,
            ApplicationUserId = Guid.NewGuid()
        };
        var mockQueryable = new List<Coach> { coach }.BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await coachService.GetCoachEditViewModel(coachId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(coach.Id));
        Assert.That(result.FirstName, Is.EqualTo(coach.FirstName));
        Assert.That(result.TeamId, Is.EqualTo(team.Id));
        Assert.That(result.Role, Is.EqualTo(coach.Role));
        Assert.That(result.ApplicationUserId, Is.EqualTo(coach.ApplicationUserId));
    }

    [Test]
    public async Task EditCoachAsync_ReturnsFalseIfRoleInvalidOrTeamNull()
    {
        var teamMockQueryable = new List<Team>().BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(teamMockQueryable);

        var model = new CoachEditViewModel
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = "Doe",
            ImageUrl = "/img.png",
            TeamId = 2,
            Role = (CoachRole)999,
            ApplicationUserId = Guid.NewGuid()
        };

        applicationUserRepositoryMock.Setup(r => r.ExistsByIdAsync(It.IsAny<Guid?>())).ReturnsAsync(false);

        var result = await coachService.EditCoachAsync(model);
        Assert.That(result, Is.False);

        model.Role = CoachRole.HeadCoach;
        result = await coachService.EditCoachAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task EditCoachAsync_UpdatesCoachAndReturnsTrue()
    {
        var team = new Team { Id = 2, Name = "TeamA" };
        var coachId = Guid.NewGuid();
        var coach = new Coach
        {
            Id = coachId,
            FirstName = "Old",
            LastName = "Coach",
            ImageUrl = "/oldimg.png",
            Team = team,
            TeamId = team.Id,
            Role = CoachRole.AssistantCoach,
            ApplicationUserId = Guid.NewGuid()
        };

        var teamMockQueryable = new List<Team> { team }.BuildMock();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(teamMockQueryable);
        applicationUserRepositoryMock.Setup(r => r.ExistsByIdAsync(It.IsAny<Guid?>())).ReturnsAsync(true);

        var coachMockQueryable = new List<Coach> { coach }.BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(coachMockQueryable);
        coachRepositoryMock.Setup(r => r.UpdateAsync(coach)).Returns(Task.FromResult(true)).Verifiable();

        var model = new CoachEditViewModel
        {
            Id = coach.Id,
            FirstName = "Jane",
            LastName = "Doe",
            ImageUrl = "/img.png",
            TeamId = team.Id,
            Role = CoachRole.HeadCoach,
            ApplicationUserId = Guid.NewGuid()
        };

        var result = await coachService.EditCoachAsync(model);

        Assert.That(result, Is.True);
        coachRepositoryMock.Verify(r => r.UpdateAsync(coach), Times.Once);
        Assert.That(coach.FirstName, Is.EqualTo(model.FirstName));
        Assert.That(coach.LastName, Is.EqualTo(model.LastName));
        Assert.That(coach.ImageUrl, Is.EqualTo(model.ImageUrl));
        Assert.That(coach.TeamId, Is.EqualTo(model.TeamId));
        Assert.That(coach.Role, Is.EqualTo(model.Role));
        Assert.That(coach.ApplicationUserId, Is.EqualTo(model.ApplicationUserId));
    }

    [Test]
    public async Task GetCoachForDeleteAsync_ReturnsNullIfIdIsNullOrEmptyOrNotFound()
    {
        var result = await coachService.GetCoachForDeleteAsync(null);
        Assert.That(result, Is.Null);

        var mockQueryable = new List<Coach>().BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        result = await coachService.GetCoachForDeleteAsync(Guid.Empty);
        Assert.That(result, Is.Null);

        result = await coachService.GetCoachForDeleteAsync(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetCoachForDeleteAsync_ReturnsDeleteViewModelIfFound()
    {
        var team = new Team { Id = 1, Name = "TeamA", ImageUrl = "/team.png" };
        var coachId = Guid.NewGuid();
        var coach = new Coach
        {
            Id = coachId,
            FirstName = "Jane",
            LastName = "Doe",
            ImageUrl = "/img.png",
            Team = team,
            Role = CoachRole.HeadCoach
        };
        var mockQueryable = new List<Coach> { coach }.BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await coachService.GetCoachForDeleteAsync(coachId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(coach.Id));
        Assert.That(result.FirstName, Is.EqualTo(coach.FirstName));
        Assert.That(result.TeamName, Is.EqualTo(team.Name));
        Assert.That(result.Role, Is.EqualTo(CoachService.GetDisplayName(CoachRole.HeadCoach)));
    }

    [Test]
    public async Task DeleteCoachAsync_ReturnsFalseIfNotFound()
    {
        coachRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Coach, bool>>>())).ReturnsAsync((Coach)null);

        var model = new CoachDeleteViewModel { Id = Guid.NewGuid() };

        var result = await coachService.DeleteCoachAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DeleteCoachAsync_DeletesCoachAndReturnsTrue()
    {
        var coach = new Coach { Id = Guid.NewGuid() };

        coachRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Coach, bool>>>())).ReturnsAsync(coach);
        coachRepositoryMock.Setup(r => r.DeleteAsync(coach)).Returns(Task.FromResult(true)).Verifiable();

        var model = new CoachDeleteViewModel { Id = coach.Id };
        var result = await coachService.DeleteCoachAsync(model);

        Assert.That(result, Is.True);
        coachRepositoryMock.Verify(r => r.DeleteAsync(coach), Times.Once);
    }

    [Test]
    public async Task GetPlayersForCoach_ReturnsNullIfCoachNotFound()
    {
        var mockQueryable = new List<Coach>().BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await coachService.GetPlayersForCoach(Guid.NewGuid());
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetPlayersForCoach_ReturnsPlayersIfCoachFound()
    {
        var team = new Team { Id = 1, Name = "TeamA" };
        var coach = new Coach
        {
            Id = Guid.NewGuid(),
            Team = team,
            TeamId = team.Id,
            ApplicationUserId = Guid.NewGuid()
        };
        var coachQueryable = new List<Coach> { coach }.BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(coachQueryable);

        var players = new List<Player>
        {
            new Player
            {
                Id = Guid.NewGuid(),
                FirstName = "Tom",
                LastName = "Player",
                PreferredFoot = PreferredFoot.Right,
                Position = "Forward",
                TeamId = team.Id,
                PositionEnum = PositionEnum.Forward,
                ImageUrl = "/player.png"
            }
        }.BuildMock();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(players);

        var result = await coachService.GetPlayersForCoach(coach.ApplicationUserId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
        var playerVm = result.First();
        Assert.That(playerVm.FirstName, Is.EqualTo("Tom"));
        Assert.That(playerVm.Position, Is.EqualTo("Forward"));
        Assert.That(playerVm.ImageUrl, Is.EqualTo("/player.png"));
    }
    [Test]
    public async Task SaveStartingLineupAsync_AddsNewWhenNoExisting()
    {
        int teamId = 123;
        Guid coachId = Guid.NewGuid();
        string formationName = "3-5-2";
        var lineupPlayersInput = new List<LineupPlayerInputModel>
        {
            new LineupPlayerInputModel { PlayerId = Guid.NewGuid(), PositionName = "Midfielder", PositionNumber = 1 }
        };

        teamStartingLineupRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<TeamStartingLineup, bool>>>()))
            .ReturnsAsync((TeamStartingLineup)null);
        teamStartingLineupRepositoryMock.Setup(r => r.AddAsync(It.IsAny<TeamStartingLineup>())).Returns(Task.CompletedTask);
        teamStartingLineupPlayerRepositoryMock.Setup(r => r.AddRangeAsync(It.IsAny<List<TeamStartingLineupPlayer>>())).Returns(Task.CompletedTask);

        await coachService.SaveStartingLineupAsync(teamId, coachId, formationName, lineupPlayersInput);

        teamStartingLineupRepositoryMock.Verify(r => r.AddAsync(It.IsAny<TeamStartingLineup>()), Times.Once);
        teamStartingLineupPlayerRepositoryMock.Verify(r => r.AddRangeAsync(It.IsAny<List<TeamStartingLineupPlayer>>()), Times.Once);
    }

    [Test]
    public void SaveStartingLineupFromViewModelAsync_ThrowsArgumentException_WhenInvalid()
    {
        var model = new CoachLineupViewModel
        {
            SelectedPlayers = null,
            SelectedPositions = null,
            SelectedFormationName = null,
            TeamId = 1
        };
        Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await coachService.SaveStartingLineupFromViewModelAsync(model, Guid.NewGuid());
        });

        model.SelectedPlayers = new List<Guid> { Guid.NewGuid() };
        model.SelectedPositions = new List<string> { "Forward", "Midfielder" };
        model.SelectedFormationName = "4-4-2";
        Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await coachService.SaveStartingLineupFromViewModelAsync(model, Guid.NewGuid());
        });
    }

    [Test]
    public async Task SaveStartingLineupFromViewModelAsync_SuccessfulFlow()
    {
        var model = new CoachLineupViewModel
        {
            TeamId = 1,
            SelectedPlayers = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() },
            SelectedPositions = new List<string> { "Forward", "Defender" },
            SelectedFormationName = "4-4-2"
        };
        teamStartingLineupRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<TeamStartingLineup, bool>>>()))
            .ReturnsAsync((TeamStartingLineup)null);
        teamStartingLineupRepositoryMock.Setup(r => r.AddAsync(It.IsAny<TeamStartingLineup>())).Returns(Task.CompletedTask);
        teamStartingLineupPlayerRepositoryMock.Setup(r => r.AddRangeAsync(It.IsAny<List<TeamStartingLineupPlayer>>())).Returns(Task.CompletedTask);

        await coachService.SaveStartingLineupFromViewModelAsync(model, Guid.NewGuid());

        teamStartingLineupRepositoryMock.Verify(r => r.AddAsync(It.IsAny<TeamStartingLineup>()), Times.Once);
        teamStartingLineupPlayerRepositoryMock.Verify(r => r.AddRangeAsync(It.IsAny<List<TeamStartingLineupPlayer>>()), Times.Once);
    }

    [Test]
    public void GetCoachTeamId_ReturnsTeamId_IfFound()
    {
        Guid coachAppId = Guid.NewGuid();
        var coach = new Coach { ApplicationUserId = coachAppId, TeamId = 42 };
        var coaches = new List<Coach> { coach };
        var mockQueryable = coaches.BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = coachService.GetCoachTeamId(coachAppId).Result;
        Assert.AreEqual(42, result);
    }

    [Test]
    public void GetCoachTeamId_ReturnsZero_IfNotFound()
    {
        var mockQueryable = new List<Coach>().BuildMock();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = coachService.GetCoachTeamId(Guid.NewGuid()).Result;
        Assert.AreEqual(0, result);
    }

    [Test]
    public async Task GetCoachByApplicationUserId_ReturnsCoachIfFound()
    {
        Guid appUserId = Guid.NewGuid();
        var coach = new Coach { ApplicationUserId = appUserId };
        coachRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Coach, bool>>>()))
            .ReturnsAsync(coach);

        var result = await coachService.GetCoachByApplicationUserId(appUserId);

        Assert.IsNotNull(result);
        Assert.AreEqual(appUserId, result.ApplicationUserId);
    }

    [Test]
    public async Task GetCoachByApplicationUserId_ReturnsNullIfNotFound()
    {
        coachRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Coach, bool>>>()))
            .ReturnsAsync((Coach)null);

        var result = await coachService.GetCoachByApplicationUserId(Guid.NewGuid());
        Assert.IsNull(result);
    }

    [Test]
    public async Task GetCoachLeague_ReturnsLeague_IfCoachAndTeamAndLeagueExist()
    {
        Guid coachAppId = Guid.NewGuid();
        var league = new League { Id = 10, Name = "Premier League" };
        var team = new Team { Id = 1, League = league };
        var coach = new Coach { ApplicationUserId = coachAppId, Team = team };
        var coaches = new List<Coach> { coach };
        var mockQueryable = coaches.BuildMockDbSet();
        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable.Object);

        var mockDbSet = mockQueryable;
        var mockDbQuery = mockQueryable.Object;

        coachRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable.Object);

        

        var result = await coachService.GetCoachLeague(coachAppId);
        Assert.IsNotNull(result);
        Assert.AreEqual(league, result);
    }

    

    
}