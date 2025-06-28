using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
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
        public TeamService(NextGenFootballDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
