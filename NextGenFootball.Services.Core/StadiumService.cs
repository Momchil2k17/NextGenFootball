using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Stadium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class StadiumService : IStadiumService
    {
        private readonly NextGenFootballDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        public StadiumService(NextGenFootballDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<bool> CreateStadiumAsync(StadiumCreateViewModel model, string userId)
        {
            bool res = false;
            ApplicationUser? user = await userManager.FindByIdAsync(userId);
            bool isValidSurface = Enum.IsDefined(typeof(SurfaceType), model.Surface);
            if (isValidSurface && user!=null) 
            {
                Stadium stadium = new Stadium
                {
                    Name = model.Name,
                    Description = model.Description,
                    Address = model.Address,
                    Capacity = model.Capacity,
                    Surface = model.Surface,
                    ImageUrl = model.ImageUrl,
                };
                await dbContext.Stadiums.AddAsync(stadium);
                await dbContext.SaveChangesAsync();
                res = true;
            }
            return res;

        }

        public async Task<IEnumerable<StadiumIndexViewModel>> GetAllStadiumsAsync()
        {
            IEnumerable<StadiumIndexViewModel> stadiums = await dbContext.Stadiums
                .AsNoTracking()
                .Select(s => new StadiumIndexViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Address = s.Address,
                    Capacity = s.Capacity,
                    Surface = s.Surface.ToString(),
                    ImageUrl = s.ImageUrl
                })
                .ToListAsync();
            return stadiums;
        }

        public async Task<StadiumDetailsViewModel?> GetStadiumDetailsAsync(int? id)
        {
            StadiumDetailsViewModel? stadium = null;
            if (id.HasValue)
            {
                Stadium? stRef = await dbContext.Stadiums
                    .AsNoTracking()
                    .SingleOrDefaultAsync(s => s.Id == id.Value);
                if (stRef != null)
                {
                    stadium = new StadiumDetailsViewModel
                    {
                        Id = stRef.Id,
                        Name = stRef.Name,
                        Description = stRef.Description,
                        Address = stRef.Address,
                        Capacity = stRef.Capacity,
                        Surface = stRef.Surface.ToString(),
                        ImageUrl = stRef.ImageUrl
                    };
                }
            }
            return stadium;
        }
    }
}
