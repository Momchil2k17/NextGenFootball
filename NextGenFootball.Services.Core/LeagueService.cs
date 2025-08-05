using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.League;
using NextGenFootball.Web.ViewModels.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class LeagueService : ILeagueService
    {
       
        private readonly ILeagueRepository leagueRepository;
        private readonly ISeasonRepository seasonRepository;
        private readonly IPlayerRepository playerRepository;
        public LeagueService(ILeagueRepository leagueRepository, ISeasonRepository seasonRepository, IPlayerRepository playerRepository)
        {
            this.leagueRepository = leagueRepository;
            this.seasonRepository = seasonRepository;
            this.playerRepository = playerRepository;
        }

        public async Task<bool> CreateLeagueAsync(LeagueCreateViewModel model)
        {
            bool res = false;
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Season? season = await this.seasonRepository
                .SingleOrDefaultAsync(s => s.Id == model.SeasonId);

            if ((isValidRegion) && (season!=null)) 
            {
                League league = new League
                {
                    Name = model.Name,
                    Region = model.Region,
                    AgeGroup = model.AgeGroup,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    SeasonId = season.Id
                };

                await this.leagueRepository.AddAsync(league);

                res = true;
            }
            return res;
        }

        public async Task<IEnumerable<LeagueIndexViewModel>> GetAllLeaguesAsync()
        {
            IEnumerable<LeagueIndexViewModel> leagues = await this.leagueRepository
                .GetAllAttached()
                .Include(l => l.Season)
                .AsNoTracking()
                .Where(l => !l.IsDeleted)
                .Select(l => new LeagueIndexViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Region = GetDisplayName(l.Region),
                    AgeGroup = l.AgeGroup,
                    SeasonName = l.Season.Name,
                    ImageUrl = l.ImageUrl
                })
                .ToListAsync();
            return leagues;
        }

        public async Task<LeagueDetailsViewModel?> GetLeagueDetailsAsync(int? id)
        {
            if (!id.HasValue)
                return null;

            var league = await leagueRepository
                .GetAllAttached()
                .Include(l => l.Season)
                .Include(l => l.Matches)
                    .ThenInclude(m => m.HomeTeam)
                .Include(l => l.Matches)
                    .ThenInclude(m => m.AwayTeam)
                .Include(l => l.Teams) 
                .AsNoTracking()
                .SingleOrDefaultAsync(l => l.Id == id.Value);

            if (league == null)
                return null;

            return new LeagueDetailsViewModel
            {
                Id = league.Id,
                Name = league.Name,
                Region = GetDisplayName(league.Region),
                AgeGroup = league.AgeGroup,
                SeasonName = league.Season?.Name ?? "Unknown",
                ImageUrl = league.ImageUrl,
                Description = league.Description,
                UpcomingMatches = await GetUpcomingMatchesAsync(league),
                Standings = await GetLeagueStandingsAsync(league),
                TopGoalscorers= this.playerRepository.GetAllAttached()
                .Include(p=>p.Team)
                .Where(p=>p.Team.LeagueId==league.Id)
                .OrderByDescending(p=>p.Goals)
                .Take(10)
                .Select(p=>new TopGoalscorerViewModel
                {
                    Goals=p.Goals,
                    PlayerId=p.Id,
                    PlayerImageUrl=p.ImageUrl,
                    PlayerName=p.FirstName+" "+p.LastName,
                    TeamImageUrl=p.Team.ImageUrl,
                    TeamName=p.Team.Name,
                })
                
            };
        }

        public async Task<LeagueEditViewModel?> GetLeagueForEditAsync(int? id)
        {
            LeagueEditViewModel? league = null;
            if (id.HasValue)
            {
                League? leagueEntity = await this.leagueRepository
                    .GetAllAttached()
                    .Include(l => l.Season)
                    .SingleOrDefaultAsync(l => l.Id == id.Value);
                if (leagueEntity != null)
                {
                    league = new LeagueEditViewModel
                    {
                        Id = leagueEntity.Id,
                        Name = leagueEntity.Name,
                        Region = leagueEntity.Region,
                        AgeGroup = leagueEntity.AgeGroup,
                        Description = leagueEntity.Description,
                        ImageUrl = leagueEntity.ImageUrl,
                        SeasonId = leagueEntity.SeasonId,
                    };
                }
            }
            return league;
        }

        public async Task<bool> EditLeagueAsync(LeagueEditViewModel model)
        {
            bool res = false;
            bool isValidRegion = Enum.IsDefined(typeof(Region), model.Region);
            Season? season = await this.seasonRepository
                .SingleOrDefaultAsync(s => s.Id == model.SeasonId);
            if ((isValidRegion) && (season != null))
            {
                League? league = await this.leagueRepository
                    .GetAllAttached()
                    .Include(l => l.Season)
                    .SingleOrDefaultAsync(l => l.Id == model.Id);
                if (league != null)
                {
                    league.Name = model.Name;
                    league.Region = model.Region;
                    league.AgeGroup = model.AgeGroup;
                    league.Description = model.Description;
                    league.ImageUrl = model.ImageUrl;
                    league.SeasonId = season.Id;
                    
                    await this.leagueRepository.UpdateAsync(league);
                    res = true;
                }
            }
            return res;
        }

        public async Task<LeagueDetailsViewModel?> GetLeagueForDeleteAsync(int? id)
        {
            LeagueDetailsViewModel? league = null;
            if (id.HasValue)
            {
                League? leagueEntity = await this.leagueRepository.GetAllAttached()
                    .Include(l => l.Season)
                    .SingleOrDefaultAsync(l => l.Id == id.Value);
                if (leagueEntity != null)
                {
                    league = new LeagueDetailsViewModel
                    {
                        Id = leagueEntity.Id,
                        Name = leagueEntity.Name,
                        Region = GetDisplayName(leagueEntity.Region),
                        AgeGroup = leagueEntity.AgeGroup,
                        SeasonName = leagueEntity.Season.Name,
                        ImageUrl = leagueEntity.ImageUrl,
                        Description = leagueEntity.Description
                    };
                }
            }
            return league;
        }

        public async Task<bool> DeleteLeagueAsync(LeagueDetailsViewModel model)
        {
            League? league = await this.leagueRepository
                .SingleOrDefaultAsync(l => l.Id == model.Id);
            if (league == null)
            {
                return false;
            }
            await this.leagueRepository.DeleteAsync(league);
            return true;
        }

        public async Task<IEnumerable<LeagueDropdownViewModel>?> GetLeaguesForDropdownAsync()
        {
            IEnumerable<LeagueDropdownViewModel>? leagues = null;
            leagues = await this.leagueRepository
                .GetAllAttached()
                .AsNoTracking()
                .Select(l => new LeagueDropdownViewModel
                {
                    Id = l.Id,
                    Name = l.Name
                })
                .ToListAsync();
            return leagues;
        }
        public Task<LeagueUpcomingMatchesViewModel> GetUpcomingMatchesAsync(League league)
        {
            var rounds = league.Matches?
                .Where(m => m.Date >= DateTime.Now && !m.IsDeleted)
                .GroupBy(m => m.Round)
                .Select(g => new RoundMatchesViewModel
                {
                    RoundNumber = g.Key,
                    Matches = g.Select(m => new MatchSummaryViewModel
                    {
                        MatchId = m.Id,
                        HomeTeamId = m.HomeTeamId,
                        HomeTeam = m.HomeTeam.Name,
                        HomeTeamImageUrl = m.HomeTeam.ImageUrl,
                        AwayTeamId = m.AwayTeamId,
                        AwayTeam = m.AwayTeam.Name,
                        AwayTeamImageUrl = m.AwayTeam?.ImageUrl,
                        Date = m.Date
                    }).ToList()
                }).OrderBy(r => r.RoundNumber).ToList()
                ?? new List<RoundMatchesViewModel>();

            return Task.FromResult(new LeagueUpcomingMatchesViewModel
            {
                LeagueId = league.Id,
                Rounds = rounds
            });
        }
        public async Task<LeagueUpcomingMatchesViewModel> GetUpcomingMatchesForTeamAsync(League leagueToFind, int teamId)
        {
            var league = await leagueRepository
                .GetAllAttached()
                .Include(l => l.Season)
                .Include(l => l.Matches)
                    .ThenInclude(m => m.HomeTeam)
                .Include(l => l.Matches)
                    .ThenInclude(m => m.AwayTeam)
                .Include(l => l.Teams)
                .AsNoTracking()
                .SingleOrDefaultAsync(l => l.Id == leagueToFind.Id);
            var matches = league.Matches?
                .Where(m => m.Date >= DateTime.Now && !m.IsDeleted &&
                    (m.HomeTeamId == teamId || m.AwayTeamId == teamId))
                .GroupBy(m => m.Round)
                .Select(g => new RoundMatchesViewModel
                {
                    RoundNumber = g.Key,
                    Matches = g.Select(m => new MatchSummaryViewModel
                    {
                        MatchId = m.Id,
                        HomeTeamId = m.HomeTeamId,
                        HomeTeam = m.HomeTeam.Name,
                        HomeTeamImageUrl = m.HomeTeam.ImageUrl,
                        AwayTeamId = m.AwayTeamId,
                        AwayTeam = m.AwayTeam.Name,
                        AwayTeamImageUrl = m.AwayTeam?.ImageUrl,
                        Date = m.Date
                    }).ToList()
                })
                .OrderBy(r => r.RoundNumber)
                .ToList()
                ?? new List<RoundMatchesViewModel>();

            return (new LeagueUpcomingMatchesViewModel
            {
                LeagueId = league.Id,
                Rounds = matches
            });
        }
        public Task<LeagueStandingsViewModel> GetLeagueStandingsAsync(League league)
        {
            // Calculate for each team
            var standings = league.Teams?.Select(team =>
            {
                var matches = league.Matches
                    .Where(m => !m.IsDeleted &&
                                (m.HomeTeamId == team.Id || m.AwayTeamId == team.Id)
                                 && m.Status==MatchStatus.Played)
                    .ToList();

                int played = matches.Count;
                int wins = matches.Count(m =>
                    (m.HomeTeamId == team.Id && m.HomeScore > m.AwayScore) ||
                    (m.AwayTeamId == team.Id && m.AwayScore > m.HomeScore));
                int draws = matches.Count(m => m.HomeScore == m.AwayScore);
                int losses = played - wins - draws;
                int goalsScored = matches.Sum(m =>
                    m.HomeTeamId == team.Id ? (m.HomeScore ?? 0) :
                    m.AwayTeamId == team.Id ? (m.AwayScore ?? 0) : 0);
                int goalsConceded = matches.Sum(m =>
                    m.HomeTeamId == team.Id ? (m.AwayScore ?? 0) :
                    m.AwayTeamId == team.Id ? (m.HomeScore ?? 0) : 0);
                int goalDifference = goalsScored - goalsConceded;
                int points = wins * 3 + draws;

                // Form last five matches (W/D/L)
                var lastFive = matches
                    .OrderByDescending(m => m.Date)
                    .Take(5)
                    .Select(m =>
                    {
                        if ((m.HomeTeamId == team.Id && m.HomeScore > m.AwayScore) ||
                            (m.AwayTeamId == team.Id && m.AwayScore > m.HomeScore))
                            return "W";
                        if (m.HomeScore == m.AwayScore)
                            return "D";
                        return "L";
                    }).ToList();

                return new TeamStandingViewModel
                {
                    TeamId = team.Id,
                    TeamName = team.Name,
                    TeamImageUrl = team.ImageUrl,
                    Played = played,
                    Wins = wins,
                    Draws = draws,
                    Losses = losses,
                    GoalsScored = goalsScored,
                    GoalsConceded = goalsConceded,
                    Points = points,
                    FormLastFive = lastFive
                };
            })
            .OrderByDescending(ts => ts.Points)
            .ThenByDescending(ts => ts.GoalDifference)
            .ThenByDescending(ts => ts.GoalsScored)
            .ToList() ?? new List<TeamStandingViewModel>();

            return Task.FromResult(new LeagueStandingsViewModel
            {
                Standings = standings
            });
        }
        public async Task<LeagueStandingsViewModel> GetCurrentStandingsAsync()
        {
            var mainLeague = await leagueRepository
                .GetAllAttached()
                .Include(l => l.Teams)
                .Include(l => l.Matches)
                .FirstOrDefaultAsync(l=>l.Id==1);

            if (mainLeague == null)
                return new LeagueStandingsViewModel { Standings = new List<TeamStandingViewModel>() };

            return await GetLeagueStandingsAsync(mainLeague);
        }

        public async Task<LeagueUpcomingMatchesViewModel> GetUpcomingMatchesForHomeAsync()
        {
            var mainLeague = await leagueRepository
                .GetAllAttached()
                .Include(l => l.Teams)
                .Include(l => l.Matches)
                .FirstOrDefaultAsync(l => l.Id == 1);

            if (mainLeague == null)
                return new LeagueUpcomingMatchesViewModel { Rounds = new List<RoundMatchesViewModel>() };

            return await GetUpcomingMatchesAsync(mainLeague);
        }
        public static string GetDisplayName(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field!, typeof(System.ComponentModel.DataAnnotations.DisplayAttribute)) as System.ComponentModel.DataAnnotations.DisplayAttribute;
            return attribute?.Name ?? value.ToString();
        }
        public DateTime GetNearestQuarter(DateTime dateTime)
        {
            int minutes = dateTime.Minute;
            int addMinutes = 15 - (minutes % 15);
            if (addMinutes == 15) addMinutes = 0; // Already on a quarter
            dateTime = new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                dateTime.Hour,
                dateTime.Minute,
                0,
                dateTime.Kind
            );
            return dateTime.AddMinutes(addMinutes);
        }

    }
}
