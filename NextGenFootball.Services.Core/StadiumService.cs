using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
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
        private readonly IStadiumRepository stadiumRepository;
        public StadiumService(IStadiumRepository stadiumRepository)
        {
            this.stadiumRepository = stadiumRepository;
            
        }

        public async Task<bool> CreateStadiumAsync(StadiumCreateViewModel model)
        {
            bool res = false;
            bool isValidSurface = Enum.IsDefined(typeof(SurfaceType), model.Surface);
            if (isValidSurface)
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
                await this.stadiumRepository.AddAsync(stadium);
                res = true;
            }
            return res;

        }

        public async Task<IEnumerable<StadiumIndexViewModel>> GetAllStadiumsAsync()
        {
            IEnumerable<StadiumIndexViewModel> stadiums = await this.stadiumRepository
                .GetAllAttached()
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
                Stadium? stRef = await this.stadiumRepository
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
        public async Task<StadiumEditViewModel?> GetStadiumForEditAsync(int? id)
        {
            StadiumEditViewModel? stadium = null;
            if (id.HasValue)
            {
                Stadium? stRef = await this.stadiumRepository
                    .SingleOrDefaultAsync(s => s.Id == id.Value);

                if (stRef != null)
                {
                    stadium = new StadiumEditViewModel
                    {
                        Id = stRef.Id,
                        Name = stRef.Name,
                        Description = stRef.Description,
                        Address = stRef.Address,
                        Capacity = stRef.Capacity,
                        Surface = stRef.Surface,
                        ImageUrl = stRef.ImageUrl
                    };
                }
            }
            return stadium;
        }
        public async Task<bool> EditStadiumAsync(StadiumEditViewModel model)
        {
            bool res = false;
            bool isValidSurface = Enum.IsDefined(typeof(SurfaceType), model.Surface);
            if (isValidSurface) 
            {
                Stadium? stadium = await this.stadiumRepository
                    .GetByIdAsync(model.Id);
                if (stadium != null)
                {
                    stadium.Name = model.Name;
                    stadium.Description = model.Description;
                    stadium.Address = model.Address;
                    stadium.Capacity = model.Capacity;
                    stadium.Surface = model.Surface;
                    stadium.ImageUrl = model.ImageUrl;

                    await this.stadiumRepository.UpdateAsync(stadium);
                    res = true;
                }
            }
            return res;
        }
        public async Task<StadiumDeleteViewModel?> GetStadiumForDeleteAsync(int? id)
        {
            StadiumDeleteViewModel? stadium = null;
            if (id.HasValue)
            {
                Stadium? stRef = await this.stadiumRepository
                    .SingleOrDefaultAsync(s => s.Id == id.Value);
                if (stRef != null)
                {
                    stadium = new StadiumDeleteViewModel
                    {
                        Id = stRef.Id,
                        Name = stRef.Name,
                        Capacity = stRef.Capacity,
                        ImageUrl = stRef.ImageUrl
                    };
                }
            }
            return stadium;
        }
        public async Task<bool> DeleteStadiumAsync(StadiumDeleteViewModel model)
        {
            Stadium? stadium = await this.stadiumRepository
                .GetByIdAsync(model.Id);
            if (stadium == null)
            {
                return false;
            }
            await this.stadiumRepository.DeleteAsync(stadium);
            return true;
        }
        public async Task<IEnumerable<StadiumDropdownViewModel>?> GetStadiumsForDropdownAsync()
        {
            IEnumerable<StadiumDropdownViewModel>? stadiums = null;
            stadiums= await this.stadiumRepository.GetAllAttached()
                .AsNoTracking()
                .Select(s => new StadiumDropdownViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
            return stadiums;
        }
    }
}
