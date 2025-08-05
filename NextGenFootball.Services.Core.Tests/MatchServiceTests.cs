using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Web.ViewModels.Match;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class MatchServiceTests
{
    private Mock<IMatchRepository> matchRepositoryMock;
    private Mock<IPlayerRepository> playerRepositoryMock;
    private Mock<ITeamRepository> teamRepositoryMock;
    private Mock<ILeagueRepository> leagueRepositoryMock;
    private Mock<IStadiumRepository> stadiumRepositoryMock;
    private Mock<ITeamStartingLineupRepository> teamStartingLineupRepositoryMock;
    private MatchService matchService;

    [SetUp]
    public void Setup()
    {
        matchRepositoryMock = new Mock<IMatchRepository>(MockBehavior.Strict);
        playerRepositoryMock = new Mock<IPlayerRepository>(MockBehavior.Strict);
        teamRepositoryMock = new Mock<ITeamRepository>(MockBehavior.Strict);
        leagueRepositoryMock = new Mock<ILeagueRepository>(MockBehavior.Strict);
        stadiumRepositoryMock = new Mock<IStadiumRepository>(MockBehavior.Strict);
        teamStartingLineupRepositoryMock = new Mock<ITeamStartingLineupRepository>(MockBehavior.Strict);

        matchService = new MatchService(
            matchRepositoryMock.Object,
            playerRepositoryMock.Object,
            teamRepositoryMock.Object,
            leagueRepositoryMock.Object,
            stadiumRepositoryMock.Object,
            teamStartingLineupRepositoryMock.Object);
    }

    [Test]
    public void AlwaysPass()
    {
        Assert.Pass();
    }

    [Test]
    public async Task CreateMatchAsync_ReturnsFalseIfHomeOrAwayTeamOrLeagueIsNullOrDateInvalid()
    {
        var model = new MatchCreateViewModel
        {
            HomeTeamId = 1,
            AwayTeamId = 2,
            Date = DateTime.Now.AddDays(-1),
            Round = 1
        };

        var homeTeams = new List<NextGenFootball.Data.Models.Team>().BuildMockDbSet();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(homeTeams.Object);

        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<NextGenFootball.Data.Models.Team, bool>>>())).ReturnsAsync((NextGenFootball.Data.Models.Team)null);
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<NextGenFootball.Data.Models.League, bool>>>())).ReturnsAsync((NextGenFootball.Data.Models.League)null);

        var result = await matchService.CreateMatchAsync(model, 1);

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task CreateMatchAsync_AddsMatchAndReturnsTrue()
    {
        var stadium = new NextGenFootball.Data.Models.Stadium { Id = 10, Name = "StadiumA" };
        var homeTeam = new NextGenFootball.Data.Models.Team { Id = 1, Name = "HomeTeam", Stadium = stadium };
        var awayTeam = new NextGenFootball.Data.Models.Team { Id = 2, Name = "AwayTeam" };
        var league = new NextGenFootball.Data.Models.League { Id = 1, Name = "LeagueA" };

        var homeTeams = new List<NextGenFootball.Data.Models.Team> { homeTeam }.BuildMockDbSet();
        teamRepositoryMock.Setup(r => r.GetAllAttached()).Returns(homeTeams.Object);

        teamRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<NextGenFootball.Data.Models.Team, bool>>>())).ReturnsAsync(awayTeam);
        leagueRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<NextGenFootball.Data.Models.League, bool>>>())).ReturnsAsync(league);
        matchRepositoryMock.Setup(r => r.AddAsync(It.IsAny<NextGenFootball.Data.Models.Match>())).Returns(Task.CompletedTask).Verifiable();

        var model = new MatchCreateViewModel
        {
            HomeTeamId = homeTeam.Id,
            AwayTeamId = awayTeam.Id,
            Date = DateTime.Now.AddDays(1),
            Round = 1
        };

        var result = await matchService.CreateMatchAsync(model, league.Id);

        Assert.That(result, Is.True);
        matchRepositoryMock.Verify(r => r.AddAsync(It.IsAny<NextGenFootball.Data.Models.Match>()), Times.Once);
    }

    [Test]
    public async Task GetAllMatchesAsync_ReturnsMappedMatches()
    {
        var stadium = new NextGenFootball.Data.Models.Stadium { Id = 10, Name = "StadiumA" };
        var homeTeam = new NextGenFootball.Data.Models.Team { Id = 1, Name = "HomeTeam", ImageUrl = "/images/home.png", Stadium = stadium };
        var awayTeam = new NextGenFootball.Data.Models.Team { Id = 2, Name = "AwayTeam", ImageUrl = "/images/away.png" };
        var league = new NextGenFootball.Data.Models.League { Id = 1, Name = "LeagueA" };

        var matches = new List<NextGenFootball.Data.Models.Match>
        {
            new NextGenFootball.Data.Models.Match
            {
                Id = 100,
                HomeTeam = homeTeam,
                HomeTeamId = homeTeam.Id,
                AwayTeam = awayTeam,
                AwayTeamId = awayTeam.Id,
                Date = DateTime.Now.AddDays(1),
                Stadium = stadium,
                StadiumId = stadium.Id,
                League = league,
                LeagueId = league.Id,
                HomeScore = 2,
                AwayScore = 1,
                Status = MatchStatus.Scheduled
            }
        };

        var mockMatchDbSet = matches.BuildMockDbSet();
        matchRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockMatchDbSet.Object);

        var result = await matchService.GetAllMatchesAsync();

        Assert.That(result.Count, Is.EqualTo(matches.Count));
        Assert.That(result.First().HomeTeamName, Is.EqualTo(homeTeam.Name));
        Assert.That(result.First().AwayTeamName, Is.EqualTo(awayTeam.Name));
        Assert.That(result.First().StadiumName, Is.EqualTo(stadium.Name));
    }

    [Test]
    public async Task GetMatchDetailsAsync_ReturnsNullIfIdIsNull()
    {
        var result = await matchService.GetMatchDetailsAsync(null);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetMatchDetailsAsync_ReturnsDetailsIfMatchFound()
    {
        var stadium = new NextGenFootball.Data.Models.Stadium { Id = 10, Name = "StadiumA" };
        var homeTeam = new NextGenFootball.Data.Models.Team { Id = 1, Name = "HomeTeam", ImageUrl = "/images/home.png", Stadium = stadium };
        var awayTeam = new NextGenFootball.Data.Models.Team { Id = 2, Name = "AwayTeam", ImageUrl = "/images/away.png" };
        var league = new NextGenFootball.Data.Models.League { Id = 1, Name = "LeagueA" };
        var playerId = Guid.NewGuid();
        var player = new NextGenFootball.Data.Models.Player { Id = playerId, FirstName = "John", LastName = "Doe", ImageUrl = "/images/player.png" };

        var eventList = new List<NextGenFootball.Data.Models.MatchEvent>
        {
            new NextGenFootball.Data.Models.MatchEvent
            {
                Minute = 10,
                PlayerId = playerId,
                StatType = "Goal",
                Team = homeTeam.Name
            }
        };

        var report = new NextGenFootball.Data.Models.MatchReport { Events = eventList };
        var match = new NextGenFootball.Data.Models.Match
        {
            Id = 100,
            HomeTeam = homeTeam,
            HomeTeamId = homeTeam.Id,
            AwayTeam = awayTeam,
            AwayTeamId = awayTeam.Id,
            Date = DateTime.Now.AddDays(1),
            Stadium = stadium,
            StadiumId = stadium.Id,
            League = league,
            LeagueId = league.Id,
            HomeScore = 2,
            AwayScore = 1,
            Status = MatchStatus.Played,
            Report = report,
            VideoUrl = "http://video.com"
        };

        var mockMatchDbSet = new List<NextGenFootball.Data.Models.Match> { match }.BuildMockDbSet();
        matchRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockMatchDbSet.Object);

        var playerList = new List<NextGenFootball.Data.Models.Player> { player };
        var mockPlayerDbSet = playerList.BuildMockDbSet();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockPlayerDbSet.Object);
        teamStartingLineupRepositoryMock.Setup(r => r.GetAllAttached())
    .Returns(new List<NextGenFootball.Data.Models.TeamStartingLineup>().BuildMockDbSet().Object);
        var result = await matchService.GetMatchDetailsAsync(match.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.HomeTeamName, Is.EqualTo(homeTeam.Name));
        Assert.That(result.StadiumName, Is.EqualTo(stadium.Name));
        Assert.That(result.Events.Count, Is.EqualTo(1));
        Assert.That(result.Events[0].PlayerName, Is.EqualTo($"{player.FirstName} {player.LastName}"));
        Assert.That(result.Events[0].PlayerImageUrl, Is.EqualTo(player.ImageUrl));
        Assert.That(result.Events[0].StatType, Is.EqualTo("Goal"));
    }

    [Test]
    public async Task GetMatchDetailsAsync_ReturnsNullIfMatchNotFound()
    {
        var mockMatchDbSet = new List<NextGenFootball.Data.Models.Match>().BuildMockDbSet();
        matchRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockMatchDbSet.Object);

        var result = await matchService.GetMatchDetailsAsync(999);

        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetLineupAsync_ReturnsNullIfNoLineup()
    {
        var mockLineupDbSet = new List<NextGenFootball.Data.Models.TeamStartingLineup>().BuildMockDbSet();
        teamStartingLineupRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockLineupDbSet.Object);

        var result = await matchService.GetLineupAsync(1);

        Assert.IsNull(result);
    }

    [Test]
    public async Task GetLineupAsync_ReturnsLineupViewModel()
    {
        var playerId = Guid.NewGuid();
        var lineupEntity = new NextGenFootball.Data.Models.TeamStartingLineup
        {
            Id = 1,
            TeamId = 1,
            FormationName = "4-4-2",
            Players = new List<NextGenFootball.Data.Models.TeamStartingLineupPlayer>
            {
                new NextGenFootball.Data.Models.TeamStartingLineupPlayer
                {
                    PlayerId = playerId,
                    PositionName = "Forward",
                    PositionNumber = 1
                }
            }
        };

        var mockLineupDbSet = new List<NextGenFootball.Data.Models.TeamStartingLineup> { lineupEntity }.BuildMockDbSet();
        teamStartingLineupRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockLineupDbSet.Object);

        var player = new NextGenFootball.Data.Models.Player { Id = playerId, FirstName = "Tom", LastName = "Striker", ImageUrl = "/img/player.png" };
        var mockPlayerDbSet = new List<NextGenFootball.Data.Models.Player> { player }.BuildMockDbSet();
        playerRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockPlayerDbSet.Object);

        var result = await matchService.GetLineupAsync(1);

        Assert.IsNotNull(result);
        Assert.That(result.FormationName, Is.EqualTo("4-4-2"));
        Assert.That(result.Players.Count, Is.EqualTo(1));
        Assert.That(result.Players[0].PlayerName, Is.EqualTo("Tom Striker"));
        Assert.That(result.Players[0].PositionName, Is.EqualTo("Forward"));
        Assert.That(result.Players[0].ImageUrl, Is.EqualTo("/img/player.png"));
    }
}