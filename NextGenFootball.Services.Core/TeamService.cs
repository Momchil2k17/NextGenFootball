using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Services.Core.Interfaces;
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
        private readonly NextGenFootballDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public TeamService(NextGenFootballDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<TeamIndexViewModel>> GetAllTeamsAsync()
        {
            IEnumerable<TeamIndexViewModel> teams = await this.dbContext.Teams
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
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field!, typeof(System.ComponentModel.DataAnnotations.DisplayAttribute)) as System.ComponentModel.DataAnnotations.DisplayAttribute;
            return attribute?.Name ?? value.ToString();
        }

        public async Task<TeamDetailsViewModel?> GetTeamDetailsAsync(int? id)
        {
            TeamDetailsViewModel? details= null;
            if (id.HasValue)
            {
                Team? team= await this.dbContext.Teams
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
                        Description = team.Description
                    };
                }
            }
            return details;
        }

        public async Task<bool> CreateTeamAsync(TeamCreateViewModel model, string userId)
        {
            bool res = false;
            ApplicationUser? user= await userManager.FindByIdAsync(userId);
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Stadium? stadium = await this.dbContext.Stadiums
                .SingleOrDefaultAsync(s => s.Id == model.StadiumId);
            League? league = await this.dbContext.Leagues
                .SingleOrDefaultAsync(l => l.Id == model.LeagueId);
            if(user!= null && isValidRegion && stadium != null && league != null)
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
                await dbContext.Teams.AddAsync(team);
                await dbContext.SaveChangesAsync();
                res = true;
            }
            return res;
        }

        public async Task<TeamEditViewModel?> GetTeamForEditAsync(int? id, string userId)
        {
            TeamEditViewModel? model = null;
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
            if (id.HasValue && user!=null )
            {
                Team? team = await this.dbContext.Teams
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

        public async Task<bool> EditTeamAsync(TeamEditViewModel model, string userId)
        {

            bool res = false;
            ApplicationUser? user = await this.userManager.FindByIdAsync(userId);
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Stadium? stadium = await this.dbContext.Stadiums
                .SingleOrDefaultAsync(s => s.Id == model.StadiumId);
            League? league = await this.dbContext.Leagues
                .SingleOrDefaultAsync(l => l.Id == model.LeagueId);
            if (user != null && isValidRegion && stadium != null && league != null)
            {
                Team? team = await this.dbContext.Teams
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

                    await dbContext.SaveChangesAsync();
                    res = true;
                }
            }
            return res;
        }
    }
}
