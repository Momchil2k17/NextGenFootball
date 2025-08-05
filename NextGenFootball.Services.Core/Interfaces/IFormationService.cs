using NextGenFootball.Web.ViewModels.Coach;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface IFormationService
    {
        public List<FormationViewModel> GetFormationsForCoach();
    }
}
