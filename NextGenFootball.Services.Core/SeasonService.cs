using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository seasonRepository;
        public SeasonService(ISeasonRepository seasonRepository)
        {
            this.seasonRepository = seasonRepository;
        }

        public async Task<bool> CreateSeasonAsync(SeasonCreateViewModel model)
        {
            bool res = false;
            if (model.StartDate < model.EndDate)
            {
                Season season = new Season
                {
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    IsCurrent = (DateTime.UtcNow >= model.StartDate && DateTime.UtcNow <= model.EndDate)
                };
                await this.seasonRepository.AddAsync(season);
                res = true;
            }
            return res;
        }

        public async Task<IEnumerable<SeasonIndexViewModel>> GetAllSeasonsAsync()
        {
            IEnumerable<SeasonIndexViewModel> seasons = await this.seasonRepository
                .GetAllAttached()
                .AsNoTracking()
                .Select(s => new SeasonIndexViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    IsCurrent = (DateTime.UtcNow >= s.StartDate && DateTime.UtcNow <= s.EndDate)
                })
                .ToListAsync();
            return seasons;
        }
        public async Task<SeasonDetailsViewModel?> GetSeasonDetailsAsync(int? id)
        {
            SeasonDetailsViewModel? season = null;
            if (id.HasValue)
            {
                Season? seasonEntity = await this.seasonRepository
                    .SingleOrDefaultAsync(s => s.Id == id.Value);
                if (seasonEntity != null)
                {
                    season=new SeasonDetailsViewModel
                    {
                        Id = seasonEntity.Id,
                        Name = seasonEntity.Name,
                        StartDate = seasonEntity.StartDate,
                        EndDate = seasonEntity.EndDate,
                        IsCurrent = seasonEntity.IsCurrent
                    };
                }
            }
            return season;
        }
        public async Task<IEnumerable<SeasonDropdownViewModel>?> GetSeasonsForDropdownAsync()
        {
            IEnumerable<SeasonDropdownViewModel>? seasons=null;
            seasons = await this.seasonRepository
                .GetAllAttached()
                .AsNoTracking()
                .Where(s => !s.IsDeleted)
                .Select(s => new SeasonDropdownViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
            return seasons;
        }

        public async Task<SeasonEditViewModel?> GetSeasonForEditAsync(int? id)
        {
            SeasonEditViewModel? season = null;
            if (id.HasValue)
            {
                Season? searchSeason = await this.seasonRepository
                    .SingleOrDefaultAsync(s => s.Id == id.Value);
                if (searchSeason != null)
                {
                    season= new SeasonEditViewModel
                    {
                        Id = searchSeason.Id,
                        Name = searchSeason.Name,
                        StartDate = searchSeason.StartDate,
                        EndDate = searchSeason.EndDate
                    };
                }
            }
            return season;

        }
        public async Task<bool> EditSeasonAsync(SeasonEditViewModel model)
        {
            bool res = false;
            Season? season = await this.seasonRepository
                .GetByIdAsync(model.Id);
            if (season != null && model.StartDate < model.EndDate)
            {
                season.Name = model.Name;
                season.StartDate = model.StartDate;
                season.EndDate = model.EndDate;
                season.IsCurrent = (DateTime.UtcNow >= model.StartDate && DateTime.UtcNow <= model.EndDate);

                await this.seasonRepository.UpdateAsync(season);
                res = true;
            }

            return res;
        }

        public async Task<SeasonDeleteViewModel?> GetSeasonForDeleteAsync(int? id)
        {
            SeasonDeleteViewModel? season = null;
            if (id.HasValue)
            {
                Season? searchSeason = await this.seasonRepository
                    .SingleOrDefaultAsync(s => s.Id == id.Value);
                if (searchSeason != null)
                {
                    season= new SeasonDeleteViewModel
                    {
                        Id = searchSeason.Id,
                        Name = searchSeason.Name,
                        StartDate = searchSeason.StartDate,
                        EndDate = searchSeason.EndDate
                    };
                }
            }
            return season;
        }
        public async Task<bool> DeleteSeasonAsync(SeasonDeleteViewModel model)
        {
            Season? season = await this.seasonRepository.GetByIdAsync(model.Id);
            if (season == null)
            {
                return false;
            }
            await this.seasonRepository.DeleteAsync(season);
            return true;
        }


    }
}
