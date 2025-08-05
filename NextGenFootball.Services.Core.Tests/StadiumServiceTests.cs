using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Stadium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class StadiumServiceTests
{
    private Mock<IStadiumRepository> stadiumRepositoryMock;
    private IStadiumService stadiumService;

    [SetUp]
    public void Setup()
    {
        stadiumRepositoryMock = new Mock<IStadiumRepository>(MockBehavior.Strict);
        stadiumService = new StadiumService(stadiumRepositoryMock.Object);
    }
    [Test]
    public void AlwaysPass()
    {
        Assert.Pass();
    }
    [Test]
    public async Task CreateStadiumAsync_ReturnsFalseIfSurfaceInvalid()
    {
        var model = new StadiumCreateViewModel
        {
            Name = "Stadium",
            Description = "Desc",
            Address = "Addr",
            Capacity = 1000,
            Surface = (SurfaceType)999,
            ImageUrl = "/img.png"
        };

        var result = await stadiumService.CreateStadiumAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task CreateStadiumAsync_AddsStadiumAndReturnsTrue()
    {
        stadiumRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Stadium>())).Returns(Task.FromResult(true)).Verifiable();

        var model = new StadiumCreateViewModel
        {
            Name = "Stadium",
            Description = "Desc",
            Address = "Addr",
            Capacity = 1000,
            Surface = SurfaceType.Grass,
            ImageUrl = "/img.png"
        };

        var result = await stadiumService.CreateStadiumAsync(model);

        Assert.That(result, Is.True);
        stadiumRepositoryMock.Verify(r => r.AddAsync(It.IsAny<Stadium>()), Times.Once);
    }

    [Test]
    public async Task GetAllStadiumsAsync_ReturnsMappedStadiums()
    {
        var stadiums = new List<Stadium>
        {
            new Stadium { Id = 1, Name = "Stadium1", Description = "Desc1", Address = "Addr1", Capacity = 1000, Surface = SurfaceType.Grass, ImageUrl = "/img1.png" },
            new Stadium { Id = 2, Name = "Stadium2", Description = "Desc2", Address = "Addr2", Capacity = 2000, Surface = SurfaceType.Artificial, ImageUrl = "/img2.png" }
        };

        var mockQueryable = stadiums.BuildMock();
        stadiumRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await stadiumService.GetAllStadiumsAsync();

        Assert.That(result.Count(), Is.EqualTo(stadiums.Count));
        Assert.That(result.Any(s => s.Name == "Stadium1"), Is.True);
        Assert.That(result.Any(s => s.Name == "Stadium2"), Is.True);
    }

    [Test]
    public async Task GetStadiumDetailsAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await stadiumService.GetStadiumDetailsAsync(null);
        Assert.That(result, Is.Null);

        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync((Stadium)null);

        result = await stadiumService.GetStadiumDetailsAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetStadiumDetailsAsync_ReturnsDetailsIfFound()
    {
        var stadium = new Stadium
        {
            Id = 5,
            Name = "Stadium",
            Description = "Desc",
            Address = "Addr",
            Capacity = 1000,
            Surface = SurfaceType.Grass,
            ImageUrl = "/img.png"
        };

        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync(stadium);

        var result = await stadiumService.GetStadiumDetailsAsync(stadium.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(stadium.Id));
        Assert.That(result.Name, Is.EqualTo(stadium.Name));
        Assert.That(result.Surface, Is.EqualTo(stadium.Surface.ToString()));
    }

    [Test]
    public async Task GetStadiumForEditAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await stadiumService.GetStadiumForEditAsync(null);
        Assert.That(result, Is.Null);

        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync((Stadium)null);

        result = await stadiumService.GetStadiumForEditAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetStadiumForEditAsync_ReturnsEditViewModelIfFound()
    {
        var stadium = new Stadium
        {
            Id = 10,
            Name = "Stadium",
            Description = "Desc",
            Address = "Addr",
            Capacity = 1000,
            Surface = SurfaceType.Artificial,
            ImageUrl = "/img.png"
        };

        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync(stadium);

        var result = await stadiumService.GetStadiumForEditAsync(stadium.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(stadium.Id));
        Assert.That(result.Name, Is.EqualTo(stadium.Name));
        Assert.That(result.Surface, Is.EqualTo(stadium.Surface));
    }

    [Test]
    public async Task EditStadiumAsync_ReturnsFalseIfSurfaceInvalidOrStadiumNotFound()
    {
        stadiumRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Stadium)null);

        var model = new StadiumEditViewModel
        {
            Id = 1,
            Name = "Stadium",
            Description = "Desc",
            Address = "Addr",
            Capacity = 1000,
            Surface = (SurfaceType)999,
            ImageUrl = "/img.png"
        };

        var result = await stadiumService.EditStadiumAsync(model);
        Assert.That(result, Is.False);

        model.Surface = SurfaceType.Grass;
        result = await stadiumService.EditStadiumAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task EditStadiumAsync_UpdatesStadiumAndReturnsTrue()
    {
        var stadium = new Stadium
        {
            Id = 5,
            Name = "Old Name",
            Description = "Old Desc",
            Address = "Old Addr",
            Capacity = 500,
            Surface = SurfaceType.Artificial,
            ImageUrl = "/oldimg.png"
        };

        stadiumRepositoryMock.Setup(r => r.GetByIdAsync(stadium.Id)).ReturnsAsync(stadium);
        stadiumRepositoryMock.Setup(r => r.UpdateAsync(stadium)).Returns(Task.FromResult(true)).Verifiable();

        var model = new StadiumEditViewModel
        {
            Id = stadium.Id,
            Name = "New Name",
            Description = "New Desc",
            Address = "New Addr",
            Capacity = 1000,
            Surface = SurfaceType.Grass,
            ImageUrl = "/newimg.png"
        };

        var result = await stadiumService.EditStadiumAsync(model);

        Assert.That(result, Is.True);
        stadiumRepositoryMock.Verify(r => r.UpdateAsync(stadium), Times.Once);
        Assert.That(stadium.Name, Is.EqualTo(model.Name));
        Assert.That(stadium.Surface, Is.EqualTo(model.Surface));
    }

    [Test]
    public async Task GetStadiumForDeleteAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await stadiumService.GetStadiumForDeleteAsync(null);
        Assert.That(result, Is.Null);

        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync((Stadium)null);

        result = await stadiumService.GetStadiumForDeleteAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetStadiumForDeleteAsync_ReturnsDeleteViewModelIfFound()
    {
        var stadium = new Stadium
        {
            Id = 5,
            Name = "Stadium",
            Capacity = 1000,
            ImageUrl = "/img.png"
        };

        stadiumRepositoryMock.Setup(r => r.SingleOrDefaultAsync(It.IsAny<Expression<Func<Stadium, bool>>>())).ReturnsAsync(stadium);

        var result = await stadiumService.GetStadiumForDeleteAsync(stadium.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(stadium.Id));
        Assert.That(result.Name, Is.EqualTo(stadium.Name));
        Assert.That(result.Capacity, Is.EqualTo(stadium.Capacity));
    }

    [Test]
    public async Task DeleteStadiumAsync_ReturnsFalseIfNotFound()
    {
        stadiumRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Stadium)null);

        var model = new StadiumDeleteViewModel { Id = 99 };

        var result = await stadiumService.DeleteStadiumAsync(model);
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task DeleteStadiumAsync_DeletesStadiumAndReturnsTrue()
    {
        var stadium = new Stadium { Id = 5 };

        stadiumRepositoryMock.Setup(r => r.GetByIdAsync(stadium.Id)).ReturnsAsync(stadium);
        stadiumRepositoryMock.Setup(r => r.DeleteAsync(stadium)).Returns(Task.FromResult(true)).Verifiable();

        var model = new StadiumDeleteViewModel { Id = stadium.Id };
        var result = await stadiumService.DeleteStadiumAsync(model);

        Assert.That(result, Is.True);
        stadiumRepositoryMock.Verify(r => r.DeleteAsync(stadium), Times.Once);
    }

    [Test]
    public async Task GetStadiumsForDropdownAsync_ReturnsDropdownModels()
    {
        var stadiums = new List<Stadium>
        {
            new Stadium { Id = 1, Name = "Stadium1" },
            new Stadium { Id = 2, Name = "Stadium2" }
        };

        var mockQueryable = stadiums.BuildMock();
        stadiumRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await stadiumService.GetStadiumsForDropdownAsync();

        Assert.That(result.Count(), Is.EqualTo(stadiums.Count));
        Assert.That(result.Any(s => s.Name == "Stadium1"), Is.True);
        Assert.That(result.Any(s => s.Name == "Stadium2"), Is.True);
    }
}