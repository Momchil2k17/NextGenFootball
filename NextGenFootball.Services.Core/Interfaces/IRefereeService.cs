using NextGenFootball.Web.ViewModels.Referee;
using NextGenFootball.Web.ViewModels.RefereeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface IRefereeService
    {
        public Task<IEnumerable<RefereeIndexViewModel>?> GetAllRefereesAsync();
        public Task<bool> CreateRefereeAsync(RefereeCreateViewModel model);
        public Task<RefereeEditViewModel?> GetRefereeByForEdit(Guid? id);
        public Task<bool> EditRefereeAsync(RefereeEditViewModel model);

    }
}
