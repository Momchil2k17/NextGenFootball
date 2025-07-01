using NextGenFootball.Web.ViewModels.Stadium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface IStadiumService
    {
        public Task<IEnumerable<StadiumIndexViewModel>> GetAllStadiumsAsync();
        public Task<bool> CreateStadiumAsync(StadiumCreateViewModel model);
        public Task<StadiumDetailsViewModel?> GetStadiumDetailsAsync(int? id);
        public Task<StadiumEditViewModel?> GetStadiumForEditAsync(int? id);
        public Task<bool> EditStadiumAsync(StadiumEditViewModel model);
        public Task<StadiumDeleteViewModel?> GetStadiumForDeleteAsync(int? id);
        public Task<bool> DeleteStadiumAsync(StadiumDeleteViewModel model);
        public Task<IEnumerable<StadiumDropdownViewModel>?> GetStadiumsForDropdownAsync();

    }
}
