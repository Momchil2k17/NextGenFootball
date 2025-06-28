using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class PlayerService : IPlayerService
    {
        private readonly NextGenFootballDbContext dbContext;
        public PlayerService(NextGenFootballDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<PlayerIndexViewModel>> GetAllPlayersAsync()
        {
            IEnumerable<PlayerIndexViewModel> players = await this.dbContext.Players
                .Include(p => p.Team)
                .Include(p=> p.Season)  
                .Select(p => new PlayerIndexViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    TeamName = p.Team.Name,
                    SeasonName = p.Season.Name,
                    PreferredFoot = p.PreferredFoot.ToString(),
                    Position = p.Position,
                    DateOfBirth = p.DateOfBirth,
                    ImageUrl = p.ImageUrl,
                    TeamImageUrl= p.Team.ImageUrl,
                })
                .ToListAsync();
            return players;


        }
    }
}
