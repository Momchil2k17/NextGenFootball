using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class CoachService : ICoachService
    {
        private readonly ICoachRepository coachRepository;
        public CoachService(ICoachRepository coachRepository)
        {
            this.coachRepository = coachRepository;
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
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field!, typeof(System.ComponentModel.DataAnnotations.DisplayAttribute)) as System.ComponentModel.DataAnnotations.DisplayAttribute;
            return attribute?.Name ?? value.ToString();
        }
    }
}
