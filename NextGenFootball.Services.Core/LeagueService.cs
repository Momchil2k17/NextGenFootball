using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class LeagueService : ILeagueService
    {
        private readonly NextGenFootballDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public LeagueService(NextGenFootballDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<bool> CreateLeagueAsync(LeagueCreateViewModel model, string userId)
        {
            bool res = false;
            ApplicationUser? user = await userManager.FindByIdAsync(userId);
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Season? season = await this.dbContext.Seasons
                .SingleOrDefaultAsync(s => s.Id == model.SeasonId && !s.IsDeleted);

            if ((user!=null) && (isValidRegion) && (season!=null)) 
            {
                League league = new League
                {
                    Name = model.Name,
                    Region = model.Region,
                    AgeGroup = model.AgeGroup,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    SeasonId = season.Id
                };

                await dbContext.Leagues.AddAsync(league);
                await dbContext.SaveChangesAsync();
                res = true;
            }
            return res;
        }

        public async Task<IEnumerable<LeagueIndexViewModel>> GetAllLeaguesAsync()
        {
            IEnumerable<LeagueIndexViewModel> leagues = await this.dbContext.Leagues
                .Where(l => !l.IsDeleted)
                .Select(l => new LeagueIndexViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Region = l.Region,
                    AgeGroup = l.AgeGroup,
                    SeasonName = l.Season.Name,
                    ImageUrl = l.ImageUrl
                })
                .ToListAsync();
            return leagues;
        }
    }
}
