using NextGenFootball.Web.ViewModels.Season;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface ISeasonService
    {
        public Task<IEnumerable<SeasonIndexViewModel>> GetAllSeasonsAsync();
        public Task<bool> CreateSeasonAsync(SeasonCreateViewModel model, string userId);
        public Task<SeasonDetailsViewModel?> GetSeasonDetailsAsync(int? id);
    }
}
