using NextGenFootball.Web.ViewModels.Coach;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface IFormationService
    {
        public List<FormationViewModel> GetFormationsForCoach();
    }
}
