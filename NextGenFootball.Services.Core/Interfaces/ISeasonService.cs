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
        public Task<SeasonEditViewModel?> GetSeasonForEditAsync(int? id, string userId);
        public Task<bool> EditSeasonAsync(SeasonEditViewModel model, string userId);
        public Task<SeasonDeleteViewModel?> GetSeasonForDeleteAsync(int? id, string userId);
        public Task<bool> DeleteSeasonAsync(SeasonDeleteViewModel model, string userId);
        public Task<IEnumerable<SeasonDropdownViewModel>?> GetSeasonsForDropdownAsync();

    }
}
