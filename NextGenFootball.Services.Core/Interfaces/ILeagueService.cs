using NextGenFootball.Web.ViewModels.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface ILeagueService
    {
        public Task<IEnumerable<LeagueIndexViewModel>> GetAllLeaguesAsync();
        public Task<bool> CreateLeagueAsync(LeagueCreateViewModel model, string userId);
        public Task<LeagueDetailsViewModel?> GetLeagueDetailsAsync(int? id);
        public Task<LeagueEditViewModel?> GetLeagueForEditAsync(int? id, string userId);
        public Task<bool> EditLeagueAsync(LeagueEditViewModel model, string userId);
        public Task<LeagueDetailsViewModel?> GetLeagueForDeleteAsync(int? id, string userId);
        public Task<bool> DeleteLeagueAsync(LeagueDetailsViewModel model, string userId);
    }
}
