using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.LeagueManager;
using NextGenFootball.Services.Core.LeagueManager.Interfaces;
using NextGenFootball.Web.ViewModels.Referee.RefereeAssignments;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class LeagueManagerDashboardServiceTests
{
    private Mock<IMatchRepository> matchRepositoryMock;
    private Mock<IRefereeRepository> refereeRepositoryMock;
    private Mock<IPlayerRepository> playerRepositoryMock;
    private Mock<ILeagueRepository> leagueRepositoryMock;
    private ILeagueManagerDashboardService dashboardService;

    [SetUp]
    public void Setup()
    {
        matchRepositoryMock = new Mock<IMatchRepository>(MockBehavior.Strict);
        refereeRepositoryMock = new Mock<IRefereeRepository>(MockBehavior.Strict);
        playerRepositoryMock = new Mock<IPlayerRepository>(MockBehavior.Strict);
        leagueRepositoryMock = new Mock<ILeagueRepository>(MockBehavior.Strict);

        dashboardService = new LeagueManagerDashboardService(
            matchRepositoryMock.Object,
            refereeRepositoryMock.Object,
            playerRepositoryMock.Object,
            leagueRepositoryMock.Object);
    }

    [Test]
    public async Task AssignRefereeToMatchAsync_ReturnsFalseIfMatchNotFound()
    {
        matchRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<NextGenFootball.Data.Models.Match, bool>>>())).ReturnsAsync((NextGenFootball.Data.Models.Match)null);

        var model = new AssignRefereeViewModel
        {
            MatchId = 10,
            LeagueId = 5,
            MainRefereeId = Guid.NewGuid(),
            AssistantReferee1Id = Guid.NewGuid(),
            AssistantReferee2Id = Guid.NewGuid()
        };

        var result = await dashboardService.AssignRefereeToMatchAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task AssignRefereeToMatchAsync_UpdatesRefereeAssignmentAndReturnsTrue()
    {
        var match = new NextGenFootball.Data.Models.Match { Id = 10, LeagueId = 5, IsDeleted = false };
        matchRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<NextGenFootball.Data.Models.Match, bool>>>())).ReturnsAsync(match);
        matchRepositoryMock.Setup(r => r.UpdateAsync(match)).Returns(Task.FromResult(true)).Verifiable();

        var model = new AssignRefereeViewModel
        {
            MatchId = match.Id,
            LeagueId = match.LeagueId,
            MainRefereeId = Guid.NewGuid(),
            AssistantReferee1Id = Guid.NewGuid(),
            AssistantReferee2Id = Guid.NewGuid()
        };

        var result = await dashboardService.AssignRefereeToMatchAsync(model);

        Assert.That(result, Is.True);
        matchRepositoryMock.Verify(r => r.UpdateAsync(match), Times.Once);
        Assert.That(match.RefereeId, Is.EqualTo(model.MainRefereeId));
        Assert.That(match.AssistantReferee1Id, Is.EqualTo(model.AssistantReferee1Id));
        Assert.That(match.AssistantReferee2Id, Is.EqualTo(model.AssistantReferee2Id));
    }

    [Test]
    public async Task GetMatchDetailsForAssignment_ReturnsEmptyViewModelIfLeagueNotFoundOrMatchNotFound()
    {
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync((League)null);

        var result = await dashboardService.GetMatchDetailsForAssignment(10, 5);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.LeagueId, Is.EqualTo(0));
        Assert.That(result.MatchId, Is.EqualTo(0));

        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync(new League { Id = 5 });
        var mockQueryable = new List<NextGenFootball.Data.Models.Match>().BuildMock();
        matchRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result2 = await dashboardService.GetMatchDetailsForAssignment(10, 5);
        Assert.That(result2, Is.Not.Null);
        Assert.That(result2.LeagueId, Is.EqualTo(0));
        Assert.That(result2.MatchId, Is.EqualTo(0));
    }

    [Test]
    public async Task GetMatchDetailsForAssignment_ReturnsPopulatedViewModelIfMatchAndLeagueFound()
    {
        var league = new League { Id = 5 };
        var homeTeam = new Team { Id = 1, Name = "Home", ImageUrl = "/home.png" };
        var awayTeam = new Team { Id = 2, Name = "Away", ImageUrl = "/away.png" };
        var referee = new Referee { Id = Guid.NewGuid(), FirstName = "Ref", LastName = "One" };
        var assistant1 = new Referee { Id = Guid.NewGuid(), FirstName = "Ref", LastName = "Two" };
        var assistant2 = new Referee { Id = Guid.NewGuid(), FirstName = "Ref", LastName = "Three" };
        var match = new NextGenFootball.Data.Models.Match
        {
            Id = 10,
            LeagueId = league.Id,
            IsDeleted = false,
            HomeTeam = homeTeam,
            AwayTeam = awayTeam,
            Date = DateTime.UtcNow.AddDays(1),
            Referee = referee,
            AssistantReferee1 = assistant1,
            AssistantReferee2 = assistant2
        };

        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync(league);

        var mockMatchQueryable = new List<NextGenFootball.Data.Models.Match> { match }.BuildMock();
        matchRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockMatchQueryable);

        var referees = new List<Referee>
        {
            referee,
            assistant1,
            assistant2
        }.BuildMock();
        refereeRepositoryMock.Setup(r => r.GetAllAttached()).Returns(referees);

        var result = await dashboardService.GetMatchDetailsForAssignment(match.Id, league.Id);

        Assert.That(result.LeagueId, Is.EqualTo(league.Id));
        Assert.That(result.MatchId, Is.EqualTo(match.Id));
        Assert.That(result.HomeTeam, Is.EqualTo(homeTeam.Name));
        Assert.That(result.HomeTeamImageUrl, Is.EqualTo(homeTeam.ImageUrl));
        Assert.That(result.AwayTeam, Is.EqualTo(awayTeam.Name));
        Assert.That(result.AwayTeamImageUrl, Is.EqualTo(awayTeam.ImageUrl));
        Assert.That(result.Date, Is.EqualTo(match.Date));
        Assert.That(result.AvailableReferees.Count, Is.EqualTo(3));
        Assert.That(result.MainRefereeId, Is.EqualTo(referee.Id));
        Assert.That(result.AssistantReferee1Id, Is.EqualTo(assistant1.Id));
        Assert.That(result.AssistantReferee2Id, Is.EqualTo(assistant2.Id));
    }

    [Test]
    public async Task GetMatchesForAssignment_ReturnsEmptyViewModelIfLeagueNotFound()
    {
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync((League)null);

        var result = await dashboardService.GetMatchesForAssignment(5);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.LeagueId, Is.EqualTo(0));
        Assert.That(result.Matches, Is.Null);
    }

    [Test]
    public async Task GetMatchesForAssignment_ReturnsPopulatedViewModelIfLeagueFound()
    {
        var league = new League { Id = 5 };
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<League, bool>>>())).ReturnsAsync(league);

        var homeTeam = new Team { Id = 1, Name = "Home", ImageUrl = "/home.png" };
        var awayTeam = new Team { Id = 2, Name = "Away", ImageUrl = "/away.png" };
        var referee = new Referee { Id = Guid.NewGuid(), FirstName = "Ref", LastName = "One" };
        var assistant1 = new Referee { Id = Guid.NewGuid(), FirstName = "Ref", LastName = "Two" };
        var assistant2 = new Referee { Id = Guid.NewGuid(), FirstName = "Ref", LastName = "Three" };
        var match = new NextGenFootball.Data.Models.Match
        {
            Id = 10,
            LeagueId = league.Id,
            IsDeleted = false,
            HomeTeam = homeTeam,
            AwayTeam = awayTeam,
            Date = DateTime.UtcNow.AddDays(1),
            Referee = referee,
            AssistantReferee1 = assistant1,
            AssistantReferee2 = assistant2
        };

        var mockMatchQueryable = new List<NextGenFootball.Data.Models.Match> { match }.BuildMock();
        matchRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockMatchQueryable);

        var result = await dashboardService.GetMatchesForAssignment(league.Id);

        Assert.That(result.LeagueId, Is.EqualTo(league.Id));
        Assert.That(result.Matches.Count, Is.EqualTo(1));
        var matchVm = result.Matches.First();
        Assert.That(matchVm.MatchId, Is.EqualTo(match.Id));
        Assert.That(matchVm.HomeTeam, Is.EqualTo(homeTeam.Name));
        Assert.That(matchVm.AwayTeam, Is.EqualTo(awayTeam.Name));
        Assert.That(matchVm.MainReferee, Is.EqualTo($"{referee.FirstName} {referee.LastName}"));
        Assert.That(matchVm.Assistant1, Is.EqualTo($"{assistant1.FirstName} {assistant1.LastName}"));
        Assert.That(matchVm.Assistant2, Is.EqualTo($"{assistant2.FirstName} {assistant2.LastName}"));
    }
}