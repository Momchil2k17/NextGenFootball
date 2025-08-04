using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;
using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static NextGenFootball.GCommon.ApplicationConstants;

namespace NextGenFootball.Services.Core
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository coachRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public CoachService(ICoachRepository coachRepository, ITeamRepository teamRepository, IApplicationUserRepository applicationUserRepository
            ,IPlayerRepository playerRepository, UserManager<ApplicationUser> userManager)
        {
            this.coachRepository = coachRepository;
            this.teamRepository = teamRepository;
            this.applicationUserRepository = applicationUserRepository;
            this.playerRepository = playerRepository;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<CoachIndexViewModel>> GetAllCoachesAsync()
        {
            IEnumerable<CoachIndexViewModel> coaches=await this.coachRepository
                .GetAllAttached()
                .Include(c=>c.Team)
                .AsNoTracking()
                .Select(c => new CoachIndexViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ImageUrl = c.ImageUrl,
                    TeamName = c.Team.Name,
                    TeamImageUrl = c.Team.ImageUrl,
                    Role = GetDisplayName(c.Role)

                })
                .ToListAsync();
            return coaches;
        }
        public async Task<CoachDetailsViewModel?> GetCoachDetailsAsync(Guid? id)
        {
            CoachDetailsViewModel? details = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid)
            {
                Coach? coach = await this.coachRepository
                    .GetAllAttached()
                    .Include(c => c.Team)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(c => c.Id == id!.Value);
                if (coach != null)
                {
                    details = new CoachDetailsViewModel
                    {
                        Id = coach.Id,
                        FirstName = coach.FirstName,
                        LastName = coach.LastName,
                        ImageUrl = coach.ImageUrl,
                        TeamName = coach.Team.Name,
                        TeamImageUrl = coach.Team.ImageUrl,
                        Role = GetDisplayName(coach.Role),
                    };
                }
            }
            return details;
        }
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field!, typeof(System.ComponentModel.DataAnnotations.DisplayAttribute)) as System.ComponentModel.DataAnnotations.DisplayAttribute;
            return attribute?.Name ?? value.ToString();
        }

        public async Task<bool> CreateCoachAsync(CoachCreateViewModel model)
        {
            bool res = false;
            bool isValidRole = Enum.IsDefined(typeof(CoachRole), model.Role);  
            Team? team=await this.teamRepository
                .GetAllAttached()
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == model.TeamId);
            if (team != null && isValidRole)
            {
                Coach coach = new Coach
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    ImageUrl = model.ImageUrl,
                    TeamId = model.TeamId,
                    Role = model.Role
                };
                await this.coachRepository.AddAsync(coach);
                res=true;
            }
            return res;
        }

        public async Task<CoachEditViewModel?> GetCoachEditViewModel(Guid? id)
        {
            CoachEditViewModel? coachEdit = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid)
            {
                Coach? coach = await this.coachRepository
                    .GetAllAttached()
                    .Include(c => c.Team)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(c => c.Id == id!.Value);
                if (coach != null)
                {
                    coachEdit = new CoachEditViewModel
                    {
                        Id = coach.Id,
                        FirstName = coach.FirstName,
                        LastName = coach.LastName,
                        ImageUrl = coach.ImageUrl,
                        TeamId = coach.TeamId,
                        Role = coach.Role,
                        ApplicationUserId = coach.ApplicationUserId,
                    };
                }
            }
            return coachEdit;
        }

        public async Task<bool> EditCoachAsync(CoachEditViewModel model)
        {
            bool res = false;
            bool isValidRole = Enum.IsDefined(typeof(CoachRole), model.Role);
            Team? team = await this.teamRepository
                .GetAllAttached()
                .AsNoTracking()
                .SingleOrDefaultAsync(t => t.Id == model.TeamId);
            bool isApplicationUserInDb = await this.applicationUserRepository
               .ExistsByIdAsync(model.ApplicationUserId);
            if (team != null && isValidRole)
            {
                Coach? coach = await this.coachRepository
                    .GetAllAttached()
                    .AsNoTracking()
                    .Include(c => c.Team)
                    .SingleOrDefaultAsync(c => c.Id == model.Id);
                if (coach != null)
                {
                    coach.FirstName = model.FirstName;
                    coach.LastName = model.LastName;
                    coach.ImageUrl = model.ImageUrl;
                    coach.TeamId = model.TeamId;
                    coach.Role = model.Role;
                    if (isApplicationUserInDb)
                    {
                        coach.ApplicationUserId = model.ApplicationUserId;
                    }
                    if (model.ApplicationUserId == null)
                    {
                        coach.ApplicationUserId = null;
                    }

                    await this.coachRepository.UpdateAsync(coach);
                    res = true;
                }
            }
            return res;

        }

        public async Task<CoachDeleteViewModel?> GetCoachForDeleteAsync(Guid? id)
        {
            CoachDeleteViewModel? coachDelete = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid)
            {
                Coach? coach = await this.coachRepository
                    .GetAllAttached()
                    .Include(c => c.Team)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(c => c.Id == id!.Value);
                if (coach != null)
                {
                    coachDelete = new CoachDeleteViewModel
                    {
                        Id = coach.Id,
                        FirstName = coach.FirstName,
                        LastName = coach.LastName,
                        ImageUrl = coach.ImageUrl,
                        TeamName = coach.Team.Name,
                        TeamImageUrl = coach.Team.ImageUrl,
                        Role = GetDisplayName(coach.Role),
                    };
                }
            }
            return coachDelete;
        }

        public async Task<bool> DeleteCoachAsync(CoachDeleteViewModel model)
        {
            Coach? coach = await this.coachRepository
                .SingleOrDefaultAsync(c => c.Id == model.Id);
            if (coach == null)
            {
                return false;
            }
            await this.coachRepository.DeleteAsync(coach);
            return true;
        }

        public async Task<IEnumerable<PlayerForCoachSquad>?> GetPlayersForCoach(Guid? coachId)
        {
            IEnumerable<PlayerForCoachSquad>? players = null;    
            Coach? coach = await this.coachRepository
                .GetAllAttached()
                .Include(c => c.Team)
                .ThenInclude(t => t.Players)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.ApplicationUserId == coachId);
            if (coach != null)
            {
                players=this.playerRepository
                    .GetAllAttached()
                    .Where(p => p.TeamId == coach.TeamId)
                    .AsNoTracking()
                    .Select(player => new PlayerForCoachSquad
                    {
                        Id = player.Id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        PreferredFoot = player.PreferredFoot.ToString(),
                        Position = player.Position,
                        ImageUrl = player.ImageUrl ?? $"/images/{NoImagePeopleUrl}",
                        PositionEnum = player.PositionEnum
                    })
                    .ToList();
            }
            return players;
        }
        public  List<FormationViewModel> GetFormationsForCoach()
        {
            return new List<FormationViewModel>
        {
            new FormationViewModel
            {
                Name = "4-3-3",
                DisplayName = "4-3-3 (Classic)",
                Positions = new List<FormationPosition>
                {
                    new FormationPosition { PositionName = "GK", DisplayLabel = "Goalkeeper", X = 50, Y = 95 },
                    new FormationPosition { PositionName = "LB", DisplayLabel = "Left Back", X = 15, Y = 80 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 35, Y = 78 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 65, Y = 78 },
                    new FormationPosition { PositionName = "RB", DisplayLabel = "Right Back", X = 85, Y = 80 },
                    new FormationPosition { PositionName = "CM", DisplayLabel = "Center Midfield", X = 30, Y = 60 },
                    new FormationPosition { PositionName = "CM", DisplayLabel = "Center Midfield", X = 50, Y = 58 },
                    new FormationPosition { PositionName = "CM", DisplayLabel = "Center Midfield", X = 70, Y = 60 },
                    new FormationPosition { PositionName = "LW", DisplayLabel = "Left Wing", X = 20, Y = 35 },
                    new FormationPosition { PositionName = "CF", DisplayLabel = "Center Forward", X = 50, Y = 20 },
                    new FormationPosition { PositionName = "RW", DisplayLabel = "Right Wing", X = 80, Y = 35 },
                }
            },
            new FormationViewModel
            {
                Name = "4-2-3-1",
                DisplayName = "4-2-3-1",
                Positions = new List<FormationPosition>
                {
                    new FormationPosition { PositionName = "GK", DisplayLabel = "Goalkeeper", X = 50, Y = 95 },
                    new FormationPosition { PositionName = "LB", DisplayLabel = "Left Back", X = 15, Y = 80 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 35, Y = 78 },
                    new FormationPosition { PositionName = "CB", DisplayLabel = "Center Back", X = 65, Y = 78 },
                    new FormationPosition { PositionName = "RB", DisplayLabel = "Right Back", X = 85, Y = 80 },
                    new FormationPosition { PositionName = "CDM", DisplayLabel = "Defensive Midfield", X = 38, Y = 63 },
                    new FormationPosition { PositionName = "CDM", DisplayLabel = "Defensive Midfield", X = 62, Y = 63 },
                    new FormationPosition { PositionName = "CAM", DisplayLabel = "Attacking Midfield", X = 50, Y = 47 },
                    new FormationPosition { PositionName = "LW", DisplayLabel = "Left Wing", X = 20, Y = 35 },
                    new FormationPosition { PositionName = "RW", DisplayLabel = "Right Wing", X = 80, Y = 35 },
                    new FormationPosition { PositionName = "ST", DisplayLabel = "Striker", X = 50, Y = 20 },
                }
            }
        };
        }
    }
}
