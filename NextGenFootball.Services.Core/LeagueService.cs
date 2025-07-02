using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class LeagueService : ILeagueService
    {
       
        private readonly ILeagueRepository leagueRepository;
        private readonly ISeasonRepository seasonRepository;
        public LeagueService(ILeagueRepository leagueRepository, ISeasonRepository seasonRepository)
        {
            this.leagueRepository = leagueRepository;
            this.seasonRepository = seasonRepository;
        }

        public async Task<bool> CreateLeagueAsync(LeagueCreateViewModel model)
        {
            bool res = false;
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Season? season = await this.seasonRepository
                .SingleOrDefaultAsync(s => s.Id == model.SeasonId);

            if ((isValidRegion) && (season!=null)) 
            {
                League league = new League
                {
                    Name = model.Name,
                    Region = model.Region,
                    AgeGroup = model.AgeGroup,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    SeasonId = season.Id
                };

                await this.leagueRepository.AddAsync(league);

                res = true;
            }
            return res;
        }

        public async Task<IEnumerable<LeagueIndexViewModel>> GetAllLeaguesAsync()
        {
            IEnumerable<LeagueIndexViewModel> leagues = await this.leagueRepository
                .GetAllAttached()
                .Include(l => l.Season)
                .AsNoTracking()
                .Where(l => !l.IsDeleted)
                .Select(l => new LeagueIndexViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Region = GetDisplayName(l.Region),
                    AgeGroup = l.AgeGroup,
                    SeasonName = l.Season.Name,
                    ImageUrl = l.ImageUrl
                })
                .ToListAsync();
            return leagues;
        }

        public async Task<LeagueDetailsViewModel?> GetLeagueDetailsAsync(int? id)
        {
            LeagueDetailsViewModel? details = null;
            if(id.HasValue)
            {
                League? league = await this.leagueRepository
                    .GetAllAttached()
                    .Include(l => l.Season)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(l => l.Id == id.Value );
                if (league != null)
                {
                    details = new LeagueDetailsViewModel
                    {
                        Id = league.Id,
                        Name = league.Name,
                        Region = GetDisplayName(league.Region),
                        AgeGroup = league.AgeGroup,
                        SeasonName = league.Season.Name,
                        ImageUrl = league.ImageUrl,
                        Description = league.Description
                    };
                }
            }
            return details;

        }

        public async Task<LeagueEditViewModel?> GetLeagueForEditAsync(int? id)
        {
            LeagueEditViewModel? league = null;
            if (id.HasValue)
            {
                League? leagueEntity = await this.leagueRepository
                    .GetAllAttached()
                    .Include(l => l.Season)
                    .SingleOrDefaultAsync(l => l.Id == id.Value);
                if (leagueEntity != null)
                {
                    league = new LeagueEditViewModel
                    {
                        Id = leagueEntity.Id,
                        Name = leagueEntity.Name,
                        Region = leagueEntity.Region,
                        AgeGroup = leagueEntity.AgeGroup,
                        Description = leagueEntity.Description,
                        ImageUrl = leagueEntity.ImageUrl,
                        SeasonId = leagueEntity.SeasonId,
                    };
                }
            }
            return league;
        }

        public async Task<bool> EditLeagueAsync(LeagueEditViewModel model)
        {
            bool res = false;
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Season? season = await this.seasonRepository
                .SingleOrDefaultAsync(s => s.Id == model.SeasonId);
            if ((isValidRegion) && (season != null))
            {
                League? league = await this.leagueRepository
                    .GetAllAttached()
                    .Include(l => l.Season)
                    .SingleOrDefaultAsync(l => l.Id == model.Id);
                if (league != null)
                {
                    league.Name = model.Name;
                    league.Region = model.Region;
                    league.AgeGroup = model.AgeGroup;
                    league.Description = model.Description;
                    league.ImageUrl = model.ImageUrl;
                    league.SeasonId = season.Id;
                    
                    await this.leagueRepository.UpdateAsync(league);
                    res = true;
                }
            }
            return res;
        }

        public async Task<LeagueDetailsViewModel?> GetLeagueForDeleteAsync(int? id)
        {
            LeagueDetailsViewModel? league = null;
            if (id.HasValue)
            {
                League? leagueEntity = await this.leagueRepository.GetAllAttached()
                    .Include(l => l.Season)
                    .SingleOrDefaultAsync(l => l.Id == id.Value);
                if (leagueEntity != null)
                {
                    league = new LeagueDetailsViewModel
                    {
                        Id = leagueEntity.Id,
                        Name = leagueEntity.Name,
                        Region = GetDisplayName(leagueEntity.Region),
                        AgeGroup = leagueEntity.AgeGroup,
                        SeasonName = leagueEntity.Season.Name,
                        ImageUrl = leagueEntity.ImageUrl,
                        Description = leagueEntity.Description
                    };
                }
            }
            return league;
        }

        public async Task<bool> DeleteLeagueAsync(LeagueDetailsViewModel model)
        {
            League? league = await this.leagueRepository
                .SingleOrDefaultAsync(l => l.Id == model.Id);
            if (league == null)
            {
                return false;
            }
            await this.leagueRepository.DeleteAsync(league);
            return true;
        }

        public async Task<IEnumerable<LeagueDropdownViewModel>?> GetLeaguesForDropdownAsync()
        {
            IEnumerable<LeagueDropdownViewModel>? leagues = null;
            leagues = await this.leagueRepository
                .GetAllAttached()
                .AsNoTracking()
                .Select(l => new LeagueDropdownViewModel
                {
                    Id = l.Id,
                    Name = l.Name
                })
                .ToListAsync();
            return leagues;
        }
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field!, typeof(System.ComponentModel.DataAnnotations.DisplayAttribute)) as System.ComponentModel.DataAnnotations.DisplayAttribute;
            return attribute?.Name ?? value.ToString();
        }

    }
}
