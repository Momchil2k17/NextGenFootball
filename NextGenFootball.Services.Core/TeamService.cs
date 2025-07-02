using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Player;
using NextGenFootball.Web.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IStadiumRepository stadiumRepository;
        private readonly ILeagueRepository leagueRepository;
        private readonly IPlayerRepository playerRepository;

        public TeamService(ITeamRepository teamRepository, IStadiumRepository stadiumRepository
            , ILeagueRepository leagueRepository,IPlayerRepository playerRepository)
        {
            this.teamRepository = teamRepository;
            this.stadiumRepository = stadiumRepository;
            this.leagueRepository = leagueRepository;
            this.playerRepository = playerRepository;
        }
        public async Task<bool> CreateTeamAsync(TeamCreateViewModel model)
        {
            bool res = false;
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Stadium? stadium = await this.stadiumRepository
                .SingleOrDefaultAsync(s => s.Id == model.StadiumId);
            League? league = await this.leagueRepository
                .SingleOrDefaultAsync(l => l.Id == model.LeagueId);
            if(isValidRegion && stadium != null && league != null)
            {
                Team team = new Team
                {
                    Name = model.Name,
                    Region = model.Region,
                    AgeGroup = model.AgeGroup,
                    ImageUrl = model.ImageUrl,
                    Description = model.Description,
                    StadiumId = stadium.Id,
                    LeagueId = league.Id
                };
                await this.teamRepository.AddAsync(team);
                res = true;
            }
            return res;
        }
        public async Task<IEnumerable<TeamIndexViewModel>> GetAllTeamsAsync()
        {
            IEnumerable<TeamIndexViewModel> teams = await this.teamRepository
                .GetAllAttached()
                .Include(t => t.Stadium)
                .Include(t => t.League)
                .Select(t => new TeamIndexViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Region = GetDisplayName(t.Region),
                    Stadium = t.Stadium.Name,
                    League = t.League.Name,
                    ImageUrl=t.ImageUrl
                })
                .ToListAsync();
            return teams;
        }

        public async Task<TeamDetailsViewModel?> GetTeamDetailsAsync(int? id)
        {
            TeamDetailsViewModel? details= null;
            if (id.HasValue)
            {
                Team? team= await this.teamRepository
                    .GetAllAttached()
                    .Include(t => t.Stadium)
                    .Include(t => t.League)
                    .FirstOrDefaultAsync(t => t.Id == id.Value);
                if (team != null)
                {
                    details = new TeamDetailsViewModel
                    {
                        Id = team.Id,
                        Name = team.Name,
                        Region = GetDisplayName(team.Region),
                        Stadium = team.Stadium.Name,
                        League = team.League.Name,
                        ImageUrl = team.ImageUrl,
                        Description = team.Description,
                        Players= await this.playerRepository
                            .GetAllAttached()
                            .Where(p => p.TeamId == team.Id && !p.IsDeleted)
                            .Select(p => new PlayerForTeamDetailsViewModel
                            {
                                Name=p.FirstName+" "+p.LastName,
                                Position = p.Position,
                                ImageUrl = p.ImageUrl,
                            })
                            .ToListAsync()
                    };
                }
            }
            return details;
        }


        public async Task<TeamEditViewModel?> GetTeamForEditAsync(int? id)
        {
            TeamEditViewModel? model = null;
            if (id.HasValue)
            {
                Team? team = await this.teamRepository
                    .GetAllAttached()
                    .Include(t => t.Stadium)
                    .Include(t => t.League)
                    .SingleOrDefaultAsync(t => t.Id == id.Value);
                if (team != null)
                {
                    model = new TeamEditViewModel
                    {
                        Id = team.Id,
                        Name = team.Name,
                        Region = team.Region,
                        AgeGroup = team.AgeGroup,
                        ImageUrl = team.ImageUrl,
                        Description = team.Description,
                        StadiumId = team.StadiumId,
                        LeagueId = team.LeagueId
                    };
                }
            }
            return model;
        }

        public async Task<bool> EditTeamAsync(TeamEditViewModel model)
        {

            bool res = false;
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Stadium? stadium = await this.stadiumRepository
                .SingleOrDefaultAsync(s => s.Id == model.StadiumId);
            League? league = await this.leagueRepository
                .SingleOrDefaultAsync(l => l.Id == model.LeagueId);
            if (isValidRegion && stadium != null && league != null)
            {
                Team? team = await this.teamRepository
                    .SingleOrDefaultAsync(t => t.Id == model.Id);
                if (team != null)
                {
                    team.Name = model.Name;
                    team.Region = model.Region;
                    team.AgeGroup = model.AgeGroup;
                    team.ImageUrl = model.ImageUrl;
                    team.Description = model.Description;
                    team.StadiumId = stadium.Id;
                    team.LeagueId = league.Id;

                    await this.teamRepository.UpdateAsync(team);
                    res = true;
                }
            }
            return res;
        }
        
        public async Task<TeamDeleteViewModel?> GetTeamForDeleteAsync(int? id)
        {
            TeamDeleteViewModel? model = null;
            if (id.HasValue)
            {
                Team? team = await this.teamRepository
                    .GetAllAttached()
                    .Include(t => t.League)
                    .SingleOrDefaultAsync(t => t.Id == id.Value);
                if (team != null)
                {
                    model = new TeamDeleteViewModel
                    {
                        Id = team.Id,
                        Name = team.Name,
                        AgeGroup = team.AgeGroup,
                        LeagueName = team.League.Name,
                    };
                }
            }
            return model;
        }

        public async Task<bool> DeleteTeamAsync(TeamDeleteViewModel model)
        {
            Team? team = await this.teamRepository
                .SingleOrDefaultAsync(t => t.Id == model.Id);
            if (team == null)
            {
                return false;
            }
            await this.teamRepository.DeleteAsync(team);
            return true;
        }

        public async Task<IEnumerable<TeamDropdownViewModel>?> GetTeamDropdownViewModelsAsync()
        {
            IEnumerable<TeamDropdownViewModel>? teams = await this.teamRepository
                .GetAllAttached()
                .Where(t => !t.IsDeleted)
                .Select(t => new TeamDropdownViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
            return teams;
        }
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field!, typeof(System.ComponentModel.DataAnnotations.DisplayAttribute)) as System.ComponentModel.DataAnnotations.DisplayAttribute;
            return attribute?.Name ?? value.ToString();
        }
    }
}
