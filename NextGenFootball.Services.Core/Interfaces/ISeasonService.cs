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
        public Task<bool> CreateSeasonAsync(SeasonCreateViewModel model);
        public Task<SeasonDetailsViewModel?> GetSeasonDetailsAsync(int? id);
        public Task<SeasonEditViewModel?> GetSeasonForEditAsync(int? id);
        public Task<bool> EditSeasonAsync(SeasonEditViewModel model);
        public Task<SeasonDeleteViewModel?> GetSeasonForDeleteAsync(int? id);
        public Task<bool> DeleteSeasonAsync(SeasonDeleteViewModel model);
        public Task<IEnumerable<SeasonDropdownViewModel>?> GetSeasonsForDropdownAsync();

    }
}
