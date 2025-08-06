using NextGenFootball.Data.Models;
using NextGenFootball.Web.ViewModels.League;

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
        public Task<LeagueUpcomingMatchesViewModel> GetUpcomingMatchesForTeamAsync(League leagueToFind, int teamId);
    }
}
