using Moq;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Season;
using MockQueryable.Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MockQueryable;

[TestFixture]
public class SeasonServiceTests
{
    private Mock<ISeasonRepository> seasonRepositoryMock;
    private ISeasonService seasonService;

    [SetUp]
    public void Setup()
    {
        this.seasonRepositoryMock = new Mock<ISeasonRepository>(MockBehavior.Strict);
        this.seasonService = new SeasonService(this.seasonRepositoryMock.Object);
    }

    [Test]
    public void AlwaysPass()
    {
        Assert.Pass();
    }

    [Test]
    public async Task CreateSeasonAsync_ValidDates_AddsSeasonAndReturnsTrue()
    {
        var model = new SeasonCreateViewModel
        {
            Name = "Test Season",
            StartDate = DateTime.UtcNow.AddDays(-1),
            EndDate = DateTime.UtcNow.AddDays(10)
        };
        seasonRepositoryMock
            .Setup(r => r.AddAsync(It.IsAny<Season>()))
            .Returns(Task.CompletedTask)
            .Verifiable();

        var result = await seasonService.CreateSeasonAsync(model);

        Assert.That(result, Is.True);
        seasonRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Season>()), Times.Once);
    }

    [Test]
    public async Task CreateSeasonAsync_InvalidDates_DoesNotAddSeasonAndReturnsFalse()
    {
        var model = new SeasonCreateViewModel
        {
            Name = "Test Season",
            StartDate = DateTime.UtcNow.AddDays(10),
            EndDate = DateTime.UtcNow.AddDays(1)
        };
        var result = await seasonService.CreateSeasonAsync(model);

        Assert.That(result, Is.False);
        seasonRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Season>()), Times.Never);
    }

    [Test]
    public async Task GetAllSeasonsAsync_ReturnsMappedSeasons()
    {
        var testSeasons = new List<Season>
    {
        new Season { Id = 1, Name = "Season 1", StartDate = DateTime.UtcNow.AddDays(-10), EndDate = DateTime.UtcNow.AddDays(10), IsDeleted = false },
        new Season { Id = 2, Name = "Season 2", StartDate = DateTime.UtcNow.AddDays(-30), EndDate = DateTime.UtcNow.AddDays(-15), IsDeleted = false }
    };

        var mockSet = testSeasons.BuildMock();

        seasonRepositoryMock
            .Setup(r => r.GetAllAttached())
            .Returns(mockSet);

        var result = await seasonService.GetAllSeasonsAsync();

        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.Any(s => s.Name == "Season 1"), Is.True);
        Assert.That(result.Any(s => s.Name == "Season 2"), Is.True);
    }

    [Test]
    public async Task GetSeasonDetailsAsync_IdIsNull_ReturnsNull()
    {
        var result = await seasonService.GetSeasonDetailsAsync(null);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetSeasonDetailsAsync_IdNotFound_ReturnsNull()
    {
        seasonRepositoryMock
            .Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>()))
            .ReturnsAsync((Season)null);

        var result = await seasonService.GetSeasonDetailsAsync(123);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetSeasonDetailsAsync_IdFound_ReturnsDetails()
    {
        var seasonEntity = new Season
        {
            Id = 1,
            Name = "Season 1",
            StartDate = DateTime.UtcNow.AddDays(-5),
            EndDate = DateTime.UtcNow.AddDays(5),
            IsCurrent = true
        };
        seasonRepositoryMock
            .Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>()))
            .ReturnsAsync(seasonEntity);

        var result = await seasonService.GetSeasonDetailsAsync(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(seasonEntity.Id));
        Assert.That(result.Name, Is.EqualTo(seasonEntity.Name));
        Assert.That(result.StartDate, Is.EqualTo(seasonEntity.StartDate));
        Assert.That(result.EndDate, Is.EqualTo(seasonEntity.EndDate));
        Assert.That(result.IsCurrent, Is.EqualTo(seasonEntity.IsCurrent));
    }

    [Test]
    public async Task GetSeasonsForDropdownAsync_ReturnsNotDeletedSeasons()
    {
        var testSeasons = new List<Season>
    {
        new Season { Id = 1, Name = "Season 1", IsDeleted = false },
        new Season { Id = 2, Name = "Season 2", IsDeleted = true },
        new Season { Id = 3, Name = "Season 3", IsDeleted = false }
    };

        var mockSet = testSeasons.BuildMock();

        seasonRepositoryMock
            .Setup(r => r.GetAllAttached())
            .Returns(mockSet);

        var result = await seasonService.GetSeasonsForDropdownAsync();

        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.Any(s => s.Name == "Season 1"), Is.True);
        Assert.That(result.Any(s => s.Name == "Season 3"), Is.True);
    }

    [Test]
    public async Task GetSeasonForEditAsync_IdIsNull_ReturnsNull()
    {
        var result = await seasonService.GetSeasonForEditAsync(null);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetSeasonForEditAsync_IdNotFound_ReturnsNull()
    {
        seasonRepositoryMock
            .Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>()))
            .ReturnsAsync((Season)null);

        var result = await seasonService.GetSeasonForEditAsync(123);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetSeasonForEditAsync_IdFound_ReturnsEditViewModel()
    {
        var seasonEntity = new Season
        {
            Id = 1,
            Name = "Season 1",
            StartDate = DateTime.UtcNow.AddDays(-5),
            EndDate = DateTime.UtcNow.AddDays(5)
        };
        seasonRepositoryMock
            .Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>()))
            .ReturnsAsync(seasonEntity);

        var result = await seasonService.GetSeasonForEditAsync(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(seasonEntity.Id));
        Assert.That(result.Name, Is.EqualTo(seasonEntity.Name));
        Assert.That(result.StartDate, Is.EqualTo(seasonEntity.StartDate));
        Assert.That(result.EndDate, Is.EqualTo(seasonEntity.EndDate));
    }

    [Test]
    public async Task EditSeasonAsync_SeasonNotFound_ReturnsFalse()
    {
        seasonRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Season)null);

        var model = new SeasonEditViewModel { Id = 1, Name = "Name", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
        var result = await seasonService.EditSeasonAsync(model);

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task EditSeasonAsync_StartDateAfterEndDate_ReturnsFalse()
    {
        var seasonEntity = new Season { Id = 1, Name = "OldName", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
        seasonRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(seasonEntity);

        var model = new SeasonEditViewModel { Id = 1, Name = "Name", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(1) };
        var result = await seasonService.EditSeasonAsync(model);

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task EditSeasonAsync_ValidEdit_UpdatesSeasonAndReturnsTrue()
    {
        var seasonEntity = new Season { Id = 1, Name = "OldName", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
        seasonRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(seasonEntity);

        seasonRepositoryMock
            .Setup(r => r.UpdateAsync(seasonEntity))
            .Returns(Task.FromResult(true));

        var model = new SeasonEditViewModel { Id = 1, Name = "NewName", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2) };
        var result = await seasonService.EditSeasonAsync(model);

        Assert.That(result, Is.True);
        Assert.That(seasonEntity.Name, Is.EqualTo("NewName"));
        seasonRepositoryMock.Verify(r => r.UpdateAsync(seasonEntity), Times.Once);
    }

    [Test]
    public async Task GetSeasonForDeleteAsync_IdIsNull_ReturnsNull()
    {
        var result = await seasonService.GetSeasonForDeleteAsync(null);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetSeasonForDeleteAsync_IdNotFound_ReturnsNull()
    {
        seasonRepositoryMock
            .Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>()))
            .ReturnsAsync((Season)null);

        var result = await seasonService.GetSeasonForDeleteAsync(123);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetSeasonForDeleteAsync_IdFound_ReturnsDeleteViewModel()
    {
        var seasonEntity = new Season { Id = 1, Name = "Season 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1) };
        seasonRepositoryMock
            .Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Season, bool>>>()))
            .ReturnsAsync(seasonEntity);

        var result = await seasonService.GetSeasonForDeleteAsync(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(seasonEntity.Id));
        Assert.That(result.Name, Is.EqualTo(seasonEntity.Name));
        Assert.That(result.StartDate, Is.EqualTo(seasonEntity.StartDate));
        Assert.That(result.EndDate, Is.EqualTo(seasonEntity.EndDate));
    }

    [Test]
    public async Task DeleteSeasonAsync_SeasonNotFound_ReturnsFalse()
    {
        seasonRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync((Season)null);

        var model = new SeasonDeleteViewModel { Id = 1 };
        var result = await seasonService.DeleteSeasonAsync(model);

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DeleteSeasonAsync_SeasonFound_DeletesAndReturnsTrue()
    {
        var seasonEntity = new Season { Id = 1, Name = "Season 1" };
        seasonRepositoryMock
            .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(seasonEntity);

        seasonRepositoryMock
            .Setup(r => r.DeleteAsync(seasonEntity))
            .Returns(Task.FromResult(true))
            .Verifiable();

        var model = new SeasonDeleteViewModel { Id = 1 };
        var result = await seasonService.DeleteSeasonAsync(model);

        Assert.That(result, Is.True);
        seasonRepositoryMock.Verify(r => r.DeleteAsync(seasonEntity), Times.Once);
    }
}