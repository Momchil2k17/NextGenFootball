using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.News;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

[TestFixture]
public class NewsServiceTests
{
    private Mock<INewsRepository> newsRepositoryMock;
    private INewsService newsService;

    [SetUp]
    public void Setup()
    {
        newsRepositoryMock = new Mock<INewsRepository>(MockBehavior.Strict);
        newsService = new NewsService(newsRepositoryMock.Object);
    }

    [Test]
    public async Task CreateNewsAsync_AddsNewsAndReturnsTrue()
    {
        newsRepositoryMock.Setup(r => r.AddAsync(It.IsAny<News>())).Returns(Task.FromResult(true)).Verifiable();

        var model = new NewsCreateViewModel
        {
            Title = "Title",
            Content = "Content",
            Author = "Author",
            ImageUrl = "/img.png"
        };

        var result = await newsService.CreateNewsAsync(model);

        Assert.That(result, Is.True);
        newsRepositoryMock.Verify(r => r.AddAsync(It.IsAny<News>()), Times.Once);
    }

    [Test]
    public async Task GetAllNewsAsync_ReturnsMappedNews()
    {
        var newsList = new List<News>
        {
            new News { Id = 1, Title = "Title1", Content = "Content1", Author = "Author1", PublishedOn = DateTime.UtcNow.AddDays(-1), ImageUrl = "/img1.png" },
            new News { Id = 2, Title = "Title2", Content = "Content2", Author = "Author2", PublishedOn = DateTime.UtcNow, ImageUrl = "/img2.png" }
        };

        var mockQueryable = newsList.BuildMock();
        newsRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await newsService.GetAllNewsAsync();

        Assert.That(result.Count(), Is.EqualTo(newsList.Count));
        Assert.That(result.Any(n => n.Title == "Title1"), Is.True);
        Assert.That(result.Any(n => n.Title == "Title2"), Is.True);
    }

    [Test]
    public async Task GetLatestNewsAsync_ReturnsLatestNews()
    {
        var newsList = new List<News>
        {
            new News { Id = 1, Title = "Old", Content = "Old Content", Author = "A", PublishedOn = DateTime.UtcNow.AddDays(-2), ImageUrl = "/img1.png" },
            new News { Id = 2, Title = "Middle", Content = "Middle Content", Author = "B", PublishedOn = DateTime.UtcNow.AddDays(-1), ImageUrl = "/img2.png" },
            new News { Id = 3, Title = "Newest", Content = "Newest Content", Author = "C", PublishedOn = DateTime.UtcNow, ImageUrl = "/img3.png" }
        };

        var mockQueryable = newsList.BuildMock();
        newsRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var result = await newsService.GetLatestNewsAsync(2);

        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.First().Title, Is.EqualTo("Newest"));
        Assert.That(result.Last().Title, Is.EqualTo("Middle"));
    }

    [Test]
    public async Task GetNewsDetailsAsync_ReturnsNullIfIdIsNullOrNotFound()
    {
        var result = await newsService.GetNewsDetailsAsync(null);
        Assert.That(result, Is.Null);

        newsRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<News, bool>>>())).ReturnsAsync((News)null);

        result = await newsService.GetNewsDetailsAsync(99);
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetNewsDetailsAsync_ReturnsDetailsIfFound()
    {
        var news = new News
        {
            Id = 5,
            Title = "Title",
            Content = "Content",
            Author = "Author",
            PublishedOn = DateTime.UtcNow,
            ImageUrl = "/img.png"
        };

        newsRepositoryMock.Setup(r => r.FirstOrDefaultAsync(It.IsAny<Expression<Func<News, bool>>>())).ReturnsAsync(news);

        var result = await newsService.GetNewsDetailsAsync(news.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(news.Id));
        Assert.That(result.Title, Is.EqualTo(news.Title));
        Assert.That(result.Content, Is.EqualTo(news.Content));
    }

    [Test]
    public async Task SearchNewsAsync_ReturnsPagedAndFilteredResults()
    {
        var newsList = new List<News>
        {
            new News { Id = 1, Title = "Football Match", Content = "Match Content", Author = "A", PublishedOn = DateTime.UtcNow.AddDays(-2), ImageUrl = "/img1.png" },
            new News { Id = 2, Title = "Basketball Game", Content = "Basket Content", Author = "B", PublishedOn = DateTime.UtcNow.AddDays(-1), ImageUrl = "/img2.png" },
            new News { Id = 3, Title = "Football Tournament", Content = "Tournament Content", Author = "C", PublishedOn = DateTime.UtcNow, ImageUrl = "/img3.png" }
        };

        var mockQueryable = newsList.BuildMock();
        newsRepositoryMock.Setup(r => r.GetAllAttached()).Returns(mockQueryable);

        var (result, totalItems) = await newsService.SearchNewsAsync("Football", 1, 2);

        Assert.That(totalItems, Is.EqualTo(2));
        Assert.That(result.Count(), Is.EqualTo(2));
        Assert.That(result.Any(n => n.Title == "Football Match"), Is.True);
        Assert.That(result.Any(n => n.Title == "Football Tournament"), Is.True);
    }
}