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
        public Task<bool> CreateStadiumAsync(StadiumCreateViewModel model,string userId);
        public Task<StadiumDetailsViewModel?> GetStadiumDetailsAsync(int? id);
        public Task<StadiumEditViewModel?> GetStadiumForEditAsync(int? id,string userId);
        public Task<bool> EditStadiumAsync(StadiumEditViewModel model, string userId);
        public Task<StadiumDeleteViewModel?> GetStadiumForDeleteAsync(int? id, string userId);
        public Task<bool> DeleteStadiumAsync(StadiumDeleteViewModel model, string userId);

    }
}
