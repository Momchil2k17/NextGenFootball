using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
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
        public SeasonService(NextGenFootballDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                    EndDate = s.EndDate
                })
                .ToListAsync();
            return seasons;
        }
    }
}
