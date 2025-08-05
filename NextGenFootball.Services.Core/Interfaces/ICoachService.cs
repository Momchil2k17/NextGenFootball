using NextGenFootball.Data.Models;
using NextGenFootball.Web.ViewModels.Coach;
using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface ICoachService
    {
        public Task<IEnumerable<CoachIndexViewModel>> GetAllCoachesAsync();
        public Task<CoachDetailsViewModel?> GetCoachDetailsAsync(Guid? id);
        public Task<bool> CreateCoachAsync(CoachCreateViewModel model);
        public Task<CoachEditViewModel?> GetCoachEditViewModel(Guid? id);
        public Task<bool> EditCoachAsync(CoachEditViewModel model); 
        public Task<CoachDeleteViewModel?> GetCoachForDeleteAsync(Guid? id);
        public Task<bool> DeleteCoachAsync(CoachDeleteViewModel model);
        public Task<IEnumerable<PlayerForCoachSquad>?> GetPlayersForCoach(Guid? coachId);
        public Task SaveStartingLineupAsync(int teamId, Guid coachId, string formationName, List<LineupPlayerInputModel> players);
        public Task SaveStartingLineupFromViewModelAsync(CoachLineupViewModel model, Guid userId);
        public Task<int> GetCoachTeamId(Guid coachId);
        public Task<Coach?> GetCoachByApplicationUserId(Guid appUserId);
        public Task<League?> GetCoachLeague(Guid coachId);

    }
}
