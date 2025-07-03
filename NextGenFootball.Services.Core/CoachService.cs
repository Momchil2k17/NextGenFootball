using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Models;
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

    }
}
