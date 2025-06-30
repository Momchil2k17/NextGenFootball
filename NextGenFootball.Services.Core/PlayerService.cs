using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
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
        private readonly UserManager<ApplicationUser> userManager;
        public PlayerService(NextGenFootballDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<bool> CreatePlayerAsync(PlayerCreateViewModel model, string userId)
        {
            bool res=false;
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
            Team? team = await this.dbContext.Teams
                .FirstOrDefaultAsync(t => t.Id == model.TeamId);
            Season? season = await this.dbContext.Seasons
                .FirstOrDefaultAsync(s => s.Id == model.SeasonId);
            bool isPreferredFootValid = Enum.IsDefined(typeof(PreferredFoot), model.PreferredFoot);
            if(user!=null && team!=null && season!=null && isPreferredFootValid)
            {
                Player player = new Player
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Position = model.Position,
                    PreferredFoot = model.PreferredFoot,
                    TeamId = team.Id,
                    SeasonId = season.Id,
                    ImageUrl = model.ImageUrl
                };
                await this.dbContext.Players.AddAsync(player);
                await this.dbContext.SaveChangesAsync();
                res = true;
            }
            return res;
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

        public async Task<PlayerEditViewModel?> GetPlayerForEditAsync(Guid? id, string userId)
        {
            PlayerEditViewModel? editModel = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
            if (isValidGuid && user!=null) 
            {
                
                Player? player = await this.dbContext.Players
                    .Include(p => p.Team)
                    .Include(p => p.Season)
                    .FirstOrDefaultAsync(p => p.Id == id!.Value);
                if (player != null)
                {
                    editModel = new PlayerEditViewModel()
                    {
                        ApplicationUserId = player.ApplicationUserId,
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        TeamId = player.TeamId,
                        SeasonId = player.SeasonId,
                        DateOfBirth = player.DateOfBirth,
                        Position = player.Position,
                        PreferredFoot = player.PreferredFoot,
                        ImageUrl = player.ImageUrl
                    };
                }
            }
            return editModel;

        }

        public async Task<bool> UpdatePlayerAsync(PlayerEditViewModel model, string userId)
        {
            bool res = false;
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
            Team? team = await this.dbContext.Teams
                .FirstOrDefaultAsync(t => t.Id == model.TeamId);
            Season? season = await this.dbContext.Seasons
                .FirstOrDefaultAsync(s => s.Id == model.SeasonId);
            bool isPreferredFootValid = Enum.IsDefined(typeof(PreferredFoot), model.PreferredFoot);
            bool isApplicationUserInDb=this.dbContext.Users.Any(u => u.Id == model.ApplicationUserId);
            if(user != null && team != null && season != null && isPreferredFootValid)
            {
                Player? player = await this.dbContext.Players
                    .FirstOrDefaultAsync(p => p.Id == model.Id);
                if (player != null)
                {
                    player.FirstName = model.FirstName;
                    player.LastName = model.LastName;
                    player.DateOfBirth = model.DateOfBirth;
                    player.Position = model.Position;
                    player.PreferredFoot = model.PreferredFoot;
                    player.TeamId = team.Id;
                    player.SeasonId = season.Id;
                    player.ImageUrl = model.ImageUrl;
                    if (isApplicationUserInDb)
                    {
                        player.ApplicationUserId = model.ApplicationUserId;
                    }
                    await this.dbContext.SaveChangesAsync();
                    res=true;
                }
            }
            return res;
        }
    }
}
