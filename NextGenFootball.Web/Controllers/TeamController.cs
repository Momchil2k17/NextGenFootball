using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Team;

namespace NextGenFootball.Web.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ITeamService teamService;
        private readonly ILeagueService leagueService;
        private readonly IStadiumService stadiumService;
        public TeamController(ITeamService teamService, ILeagueService leagueService, IStadiumService stadiumService)
        {
            this.teamService = teamService;
            this.leagueService = leagueService;
            this.stadiumService = stadiumService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<TeamIndexViewModel> teams = await this.teamService.GetAllTeamsAsync();
            return View(teams);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            TeamDetailsViewModel? team = await this.teamService.GetTeamDetailsAsync(id);
            if (team == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TeamCreateViewModel teamCreateViewModel = new TeamCreateViewModel
            {
                Leagues = await this.leagueService.GetLeaguesForDropdownAsync(),
                Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync()
            };
            return View(teamCreateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                return View(model);
            }

            bool isCreated = await this.teamService.CreateTeamAsync(model);
            if (!isCreated)
            {
                ModelState.AddModelError(string.Empty, "Team creation failed. Please try again.");
                model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            TeamEditViewModel? teamEditViewModel = await this.teamService.GetTeamForEditAsync(id);
            if (teamEditViewModel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            teamEditViewModel.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
            teamEditViewModel.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
            return View(teamEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeamEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                return View(model);
            }
            bool isEdited = await this.teamService.EditTeamAsync(model);
            if (!isEdited)
            {
                ModelState.AddModelError(string.Empty, "Team edit failed. Please try again.");
                model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            TeamDeleteViewModel? teamDeleteViewModel = await this.teamService.GetTeamForDeleteAsync(id);
            if (teamDeleteViewModel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(teamDeleteViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TeamDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isDeleted = await this.teamService.DeleteTeamAsync(model);
            if (!isDeleted)
            {
                ModelState.AddModelError(string.Empty, "Team deletion failed. Please try again.");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
