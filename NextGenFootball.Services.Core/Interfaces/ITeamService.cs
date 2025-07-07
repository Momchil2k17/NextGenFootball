using NextGenFootball.Web.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface ITeamService
    {
        public Task<IEnumerable<TeamIndexViewModel>> GetAllTeamsAsync();
        public Task<TeamDetailsViewModel?> GetTeamDetailsAsync(int? id);
        public Task<bool> CreateTeamAsync(TeamCreateViewModel model);
        public Task<TeamEditViewModel?> GetTeamForEditAsync(int? id);
        public Task<bool> EditTeamAsync(TeamEditViewModel model);
        public Task<TeamDeleteViewModel?> GetTeamForDeleteAsync(int? id);
        public Task<bool> DeleteTeamAsync(TeamDeleteViewModel model);
        public Task<IEnumerable<TeamDropdownViewModel>?> GetTeamDropdownViewModelsAsync();
        public Task<IEnumerable<TeamDropdownViewModel>?> GetTeamDropdownViewModelsByLeagueAsync(int? id);

    }
}
