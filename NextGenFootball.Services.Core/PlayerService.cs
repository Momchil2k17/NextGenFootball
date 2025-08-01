using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Services.Core
{
    public class PlayerService : IPlayerService
    {
        
        private readonly IPlayerRepository playerRepository;
        private readonly ITeamRepository teamRepository;
        private readonly ISeasonRepository seasonRepository;
        private readonly IApplicationUserRepository applicationUserRepository;
        public PlayerService(IPlayerRepository playerRepository, ITeamRepository teamRepository
            , ISeasonRepository seasonRepository, IApplicationUserRepository applicationUserRepository)
        {
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
            this.seasonRepository = seasonRepository;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<bool> CreatePlayerAsync(PlayerCreateViewModel model)
        {
            bool res=false;
            Team? team = await this.teamRepository
                .SingleOrDefaultAsync(t => t.Id == model.TeamId);
            Season? season = await this.seasonRepository
                .SingleOrDefaultAsync(s => s.Id == model.SeasonId);
            bool isPreferredFootValid = Enum.IsDefined(typeof(PreferredFoot), model.PreferredFoot);
            bool isPositionEnumValid = Enum.IsDefined(typeof(PositionEnum), model.PositionEnum);
            if (team!=null && season!=null && isPreferredFootValid && isPositionEnumValid)
            {
                Player player = new Player
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    Position = model.Position,
                    PositionEnum = model.PositionEnum,
                    PreferredFoot = model.PreferredFoot,
                    TeamId = team.Id,
                    SeasonId = season.Id,
                    ImageUrl = model.ImageUrl ?? $"/images/{NoImagePeopleUrl}",
                };
                await this.playerRepository.AddAsync(player);
                res = true;
            }
            return res;
        }
        public async Task<IEnumerable<PlayerIndexViewModel>> GetAllPlayersAsync()
        {
            IEnumerable<PlayerIndexViewModel> players = await this.playerRepository
                .GetAllAttached()
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
                    ImageUrl = p.ImageUrl ?? $"/images/{NoImagePeopleUrl}",
                    TeamImageUrl = p.Team.ImageUrl,
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
                Player? player = await this.playerRepository
                    .GetAllAttached()
                    .Include(p => p.Team)
                    .Include(p => p.Season)
                    .SingleOrDefaultAsync(p => p.Id == id!.Value);
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
                        ImageUrl = player.ImageUrl ?? $"/images/{NoImagePeopleUrl}",
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
        public async Task<PlayerEditViewModel?> GetPlayerForEditAsync(Guid? id)
        {
            PlayerEditViewModel? editModel = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid) 
            {
                
                Player? player = await this.playerRepository
                    .GetAllAttached()
                    .Include(p => p.Team)
                    .Include(p => p.Season)
                    .SingleOrDefaultAsync(p => p.Id == id!.Value);
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
                        PositionEnum = player.PositionEnum,
                        PreferredFoot = player.PreferredFoot,
                        ImageUrl = player.ImageUrl ?? ""
                    };
                }
            }
            return editModel;

        }
        public async Task<bool> UpdatePlayerAsync(PlayerEditViewModel model)
        {
            bool res = false;
            Team? team = await this.teamRepository
                .SingleOrDefaultAsync(t => t.Id == model.TeamId);
            Season? season = await this.seasonRepository
                .SingleOrDefaultAsync(s => s.Id == model.SeasonId);
            bool isPreferredFootValid = Enum.IsDefined(typeof(PreferredFoot), model.PreferredFoot);
            bool isApplicationUserInDb=await this.applicationUserRepository
                .ExistsByIdAsync(model.ApplicationUserId);
            bool isPositionEnumValid = Enum.IsDefined(typeof(PositionEnum), model.PositionEnum);
            if (team != null && season != null && isPreferredFootValid)
            {
                Player? player = await this.playerRepository
                    .GetAllAttached()
                    .Include(p => p.Team)
                    .Include(p => p.Season)
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
                    player.PositionEnum = model.PositionEnum;
                    if (isApplicationUserInDb)
                    {
                        player.ApplicationUserId = model.ApplicationUserId;
                    }
                    if (model.ApplicationUserId == null)
                    {
                        player.ApplicationUserId = null;
                    }
                    await this.playerRepository.UpdateAsync(player);
                    res=true;
                }
            }
            return res;
        }
        public async Task<PlayerStatsEditViewModel?> GetPlayerStatsForEditAsync(Guid? id)
        {
            PlayerStatsEditViewModel? statsEditModel = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid)
            {
                Player? player = await this.playerRepository
                    .SingleOrDefaultAsync(p => p.Id == id!.Value);
                if (player != null)
                {
                    statsEditModel = new PlayerStatsEditViewModel()
                    {
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        Goals = player.Goals,
                        MinutesPlayed = player.MinutesPlayed,
                        RedCards = player.RedCards,
                        YellowCards = player.YellowCards,
                        Assists = player.Assists
                    };
                } 
            }
            return statsEditModel;
        }
        public async Task<bool> UpdatePlayerStatsAsync(PlayerStatsEditViewModel model)
        {
            bool res = false;

            Player? player = await this.playerRepository
                .SingleOrDefaultAsync(p => p.Id == model.Id);
            if (player != null)
            {
                player.Goals = model.Goals;
                player.MinutesPlayed = model.MinutesPlayed;
                player.RedCards = model.RedCards;
                player.YellowCards = model.YellowCards;
                player.Assists = model.Assists;

                await this.playerRepository.UpdateAsync(player);
                res = true;
            }
            return res;

        }
        public async Task<PlayerDeleteViewModel?> GetPlayerForDeleteAsync(Guid? id)
        {
            PlayerDeleteViewModel? deleteModel = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid)
            {
                Player? player = await this.playerRepository
                    .GetAllAttached()
                    .Include(p => p.Team)
                    .Include(p => p.Season)
                    .SingleOrDefaultAsync(p => p.Id == id!.Value);
                if (player != null)
                {
                    deleteModel = new PlayerDeleteViewModel()
                    {
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        TeamName = player.Team.Name,
                    };
                }
            }
            return deleteModel;
        }
        public async Task<bool> DeletePlayerAsync(PlayerDeleteViewModel model)
        {
            Player? player = await this.playerRepository
                .SingleOrDefaultAsync(p => p.Id == model.Id);
            if (player == null)
            {
                return false;
            }
            await this.playerRepository.DeleteAsync(player);
            return true;
        }


    }
}
