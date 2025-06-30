using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface IPlayerService
    {
        public Task<IEnumerable<PlayerIndexViewModel>> GetAllPlayersAsync();
        public Task<PlayerDetailsViewModel?> GetPlayerDetailsAsync(Guid? id);
        public Task<bool> CreatePlayerAsync(PlayerCreateViewModel model, string userId);
        public Task<PlayerEditViewModel?> GetPlayerForEditAsync(Guid? id, string userId);
        public Task<bool> UpdatePlayerAsync(PlayerEditViewModel model, string userId);
    }
}
