using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Models;
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

        public async Task<PlayerDetailsViewModel?> GetPlayerDetailsAsync(Guid? id)
        {
            PlayerDetailsViewModel? details = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid)
            {
                Player? player = await this.dbContext.Players
                    .Include(p => p.Team)
                    .Include(p => p.Season)
                    .FirstOrDefaultAsync(p => p.Id == id!.Value);
                if (player != null)
                {
                    details = new PlayerDetailsViewModel()
                    {
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        TeamName = player.Team!.Name,
                        TeamImageUrl = player.Team!.ImageUrl!,
                        PreferredFoot = player.PreferredFoot.ToString(),
                        DateOfBirth = player.DateOfBirth,
                        ImageUrl = player.ImageUrl,
                        Goals = player.Goals,
                        Assists = player.Assists,
                        MinutesPlayed = player.MinutesPlayed,
                        YellowCards = player.YellowCards,
                        RedCards = player.RedCards
                    };
                }
            }
            return details;
        }
    }
}
