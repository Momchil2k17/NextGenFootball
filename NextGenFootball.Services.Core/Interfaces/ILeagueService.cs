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
        public Task<bool> CreateLeagueAsync(LeagueCreateViewModel model);
        public Task<LeagueDetailsViewModel?> GetLeagueDetailsAsync(int? id);
        public Task<LeagueEditViewModel?> GetLeagueForEditAsync(int? id);
        public Task<bool> EditLeagueAsync(LeagueEditViewModel model);
        public Task<LeagueDetailsViewModel?> GetLeagueForDeleteAsync(int? id);
        public Task<bool> DeleteLeagueAsync(LeagueDetailsViewModel model);
        public Task<IEnumerable<LeagueDropdownViewModel>?> GetLeaguesForDropdownAsync();
        DateTime GetNearestQuarter(DateTime dateTime);
        public Task<LeagueUpcomingMatchesViewModel> GetUpcomingMatchesForHomeAsync();
        public Task<LeagueStandingsViewModel> GetCurrentStandingsAsync();
    }
}
