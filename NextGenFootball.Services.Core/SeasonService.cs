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
    }
}
