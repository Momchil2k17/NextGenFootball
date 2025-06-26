using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Models;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class SeasonService : ISeasonService
    {
        private readonly NextGenFootballDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public SeasonService(NextGenFootballDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<bool> CreateSeasonAsync(SeasonCreateViewModel model, string userId)
        {
            bool res = false;
            ApplicationUser? user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if(model.StartDate < model.EndDate)
                {
                    Season season = new Season
                    {
                        Name = model.Name,
                        StartDate = model.StartDate,
                        EndDate = model.EndDate,
                        IsCurrent=(DateTime.UtcNow >= model.StartDate && DateTime.UtcNow <= model.EndDate)
                    };
                    await dbContext.Seasons.AddAsync(season);
                    await dbContext.SaveChangesAsync();
                    res = true;
                }
            }
            return res;
        }

        public async Task<bool> DeleteSeasonAsync(SeasonDeleteViewModel model, string userId)
        {
            bool res = false;
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                Season? season = await this.dbContext.Seasons
                    .SingleOrDefaultAsync(s => s.Id == model.Id);
                if (season != null)
                {
                    season.IsDeleted = true; // Soft delete

                    await this.dbContext.SaveChangesAsync();
                    res = true;
                }
            }
            return res;
        }

        public async Task<bool> EditSeasonAsync(SeasonEditViewModel model, string userId)
        {
            bool res = false;
            ApplicationUser? user =await this.userManager.FindByIdAsync(userId);
            if (user != null)
            {
                Season? season = this.dbContext.Seasons
                    .SingleOrDefault(s => s.Id == model.Id);
                if (season != null && model.StartDate<model.EndDate)
                {
                    season.Name = model.Name;
                    season.StartDate = model.StartDate;
                    season.EndDate = model.EndDate;
                    season.IsCurrent = (DateTime.UtcNow >= model.StartDate && DateTime.UtcNow <= model.EndDate);

                    await this.dbContext.SaveChangesAsync();
                    res = true;
                }
            }
            return res;
        }

        public async Task<IEnumerable<SeasonIndexViewModel>> GetAllSeasonsAsync()
        {
            IEnumerable<SeasonIndexViewModel> seasons = await this.dbContext.Seasons
                .AsNoTracking()
                .Select(s => new SeasonIndexViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    IsCurrent = s.IsCurrent
                })
                .ToListAsync();
            return seasons;
        }

        public Task<SeasonDetailsViewModel?> GetSeasonDetailsAsync(int? id)
        {
            SeasonDetailsViewModel? season = null;
            if (id.HasValue)
            {
                season = this.dbContext.Seasons
                    .AsNoTracking()
                    .Where(s => s.Id == id.Value)
                    .Select(s => new SeasonDetailsViewModel
                    {
                        Id = s.Id,
                        Name = s.Name,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate,
                        IsCurrent = s.IsCurrent
                    })
                    .FirstOrDefault();
            }
            return Task.FromResult(season);
        }

        public async Task<SeasonDeleteViewModel?> GetSeasonForDeleteAsync(int? id, string userId)
        {
            SeasonDeleteViewModel? season = null;
            if (id.HasValue)
            {
                ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    season = this.dbContext.Seasons
                        .AsNoTracking()
                        .Where(s => s.Id == id.Value)
                        .Select(s => new SeasonDeleteViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                        })
                        .FirstOrDefault();
                }
            }
            return season;
        }


        public async Task<SeasonEditViewModel?> GetSeasonForEditAsync(int? id, string userId)
        {
            SeasonEditViewModel? season = null;
            if (id.HasValue)
            {
                ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    season = this.dbContext.Seasons
                        .AsNoTracking()
                        .Where(s => s.Id == id.Value)
                        .Select(s => new SeasonEditViewModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                            IsCurrent = s.IsCurrent
                        })
                        .FirstOrDefault();
                }
            }
            return season;

        }

        public async Task<IEnumerable<SeasonDropdownViewModel>?> GetSeasonsForDropdownAsync()
        {
            IEnumerable<SeasonDropdownViewModel>? seasons=null;
            seasons = await this.dbContext.Seasons
                .AsNoTracking()
                .Where(s => !s.IsDeleted)
                .Select(s => new SeasonDropdownViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
            return seasons;
        }
    }
}
