using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
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
        public LeagueService(NextGenFootballDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<LeagueIndexViewModel>> GetAllLeaguesAsync()
        {
            IEnumerable<LeagueIndexViewModel> leagues = await this.dbContext.Leagues
                .Where(l => !l.IsDeleted)
                .Select(l => new LeagueIndexViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Region = l.Region.ToString(),
                    AgeGroup = l.AgeGroup,
                    SeasonName = l.Season.Name,
                    ImageUrl = l.ImageUrl
                })
                .ToListAsync();
            return leagues;
        }
    }
}
