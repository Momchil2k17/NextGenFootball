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
            try
            {
                TeamDetailsViewModel? team = await this.teamService.GetTeamDetailsAsync(id);
                if (team == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(team);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
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
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                    model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                    return View(model);
                }
                string userId = this.GetUserId()!;
                bool isCreated = await this.teamService.CreateTeamAsync(model, userId);
                if (!isCreated)
                {
                    ModelState.AddModelError(string.Empty, "Team creation failed. Please try again.");
                    model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                    model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = this.GetUserId()!;
                TeamEditViewModel? teamEditViewModel = await this.teamService.GetTeamForEditAsync(id, userId);
                if (teamEditViewModel == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                teamEditViewModel.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                teamEditViewModel.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                return View(teamEditViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeamEditViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                    model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                    return View(model);
                }
                string userId = this.GetUserId()!;
                bool isEdited = await this.teamService.EditTeamAsync(model, userId);
                if (!isEdited)
                {
                    ModelState.AddModelError(string.Empty, "Team edit failed. Please try again.");
                    model.Leagues = await this.leagueService.GetLeaguesForDropdownAsync();
                    model.Stadiums = await this.stadiumService.GetStadiumsForDropdownAsync();
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
