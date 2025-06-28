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
        public Task<bool> CreateTeamAsync(TeamCreateViewModel model, string userId);
        public Task<TeamEditViewModel?> GetTeamForEditAsync(int? id, string userId);
        public Task<bool> EditTeamAsync(TeamEditViewModel model, string userId);
        public Task<TeamDeleteViewModel?> GetTeamForDeleteAsync(int? id, string userId);
        public Task<bool> DeleteTeamAsync(TeamDeleteViewModel model, string userId);

    }
}
