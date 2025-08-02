using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.News;
using NextGenFootball.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NextGenFootball.Data.Models;

namespace NextGenFootball.Services.Core
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<bool> CreateNewsAsync(NewsCreateViewModel model)
        {
            bool res = false;
            News news = new News
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                PublishedOn = DateTime.UtcNow,
                ImageUrl = model.ImageUrl
            };
            if(news != null)
            {
                await this.newsRepository.AddAsync(news);
                res = true;
            }
            return res;
        }

        public async Task<IEnumerable<NewsIndexViewModel>?> GetAllNewsAsync()
        {
            IEnumerable<NewsIndexViewModel>? news = null;
            news= this.newsRepository
                .GetAllAttached()
                .Select(n => new NewsIndexViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Author = n.Author,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl
                })
                .ToList();
            return news;
        }

        public async Task<IEnumerable<NewsIndexViewModel>?> GetLatestNewsAsync(int count)
        {
            IEnumerable<NewsIndexViewModel>? latestNews = null;
            latestNews = this.newsRepository
                .GetAllAttached()
                .OrderByDescending(n => n.PublishedOn)
                .Take(count)
                .Select(n => new NewsIndexViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Author = n.Author,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl
                })
                .ToList();
            return latestNews;
        }

        public async Task<NewsDetailsViewModel?> GetNewsDetailsAsync(int? id)
        {
            NewsDetailsViewModel? details = null;   
            if (id.HasValue)
            {
                News? news= await this.newsRepository
                    .FirstOrDefaultAsync(n => n.Id == id.Value);
                if (news != null)
                {
                    details = new NewsDetailsViewModel
                    {
                        Id = news.Id,
                        Title = news.Title,
                        Content = news.Content,
                        Author = news.Author,
                        PublishedOn = news.PublishedOn,
                        ImageUrl = news.ImageUrl
                    };
                }
            }
            return details;
        }
        public async Task<(IEnumerable<NewsIndexViewModel> News, int TotalItems)> SearchNewsAsync(string? searchTerm, int page, int pageSize)
        {
            var query = this.newsRepository.GetAllAttached();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(n =>
                    n.Title.Contains(searchTerm)
                );
            }

            var totalItems = query.Count();

            var news = query
                .OrderByDescending(n => n.PublishedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(n => new NewsIndexViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Author = n.Author,
                    PublishedOn = n.PublishedOn,
                    ImageUrl = n.ImageUrl
                })
                .ToList();

            return (news, totalItems);
        }
    }
}
