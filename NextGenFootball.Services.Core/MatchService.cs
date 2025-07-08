using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Enums;
using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository matchRepository;
        private readonly ITeamRepository teamRepository;
        private readonly ILeagueRepository leagueRepository;
        private readonly IStadiumRepository stadiumRepository;
        public MatchService(IMatchRepository matchRepository, ITeamRepository teamRepository, ILeagueRepository leagueRepository, IStadiumRepository stadiumRepository)
        {
            this.matchRepository = matchRepository;
            this.teamRepository = teamRepository;
            this.leagueRepository = leagueRepository;
            this.stadiumRepository = stadiumRepository;
        }

        public async Task<bool> CreateMatchAsync(MatchCreateViewModel model,int? id)
        {
            bool res = false;
            Team? homeTeam=await this.teamRepository.GetAllAttached()
                .Include(t=>t.Stadium)
                .SingleOrDefaultAsync(t => t.Id == model.HomeTeamId);
            Team? awayTeam=await this.teamRepository.SingleOrDefaultAsync(t => t.Id == model.AwayTeamId);
            League? league = await this.leagueRepository.SingleOrDefaultAsync(l => l.Id == id);
            bool isValidDate = model.Date > DateTime.Now;
            if (homeTeam != null && awayTeam != null && league != null && isValidDate)
            {
                Match match = new Match
                {
                    HomeTeamId = homeTeam.Id,
                    AwayTeamId = awayTeam.Id,
                    Date = model.Date,
                    StadiumId = homeTeam.Stadium.Id,
                    LeagueId = league.Id,
                    Status = MatchStatus.Scheduled
                };
                await this.matchRepository.AddAsync(match);
                res = true;
            }
            return res;

        }

        public async Task<IEnumerable<MatchIndexViewModel>> GetAllMatchesAsync()
        {
            IEnumerable<MatchIndexViewModel> matches = await this.matchRepository
                .GetAllAttached()
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.League)
                .Include(m => m.Stadium)
                .AsNoTracking()
                .Select(m => new MatchIndexViewModel
                {
                    Id = m.Id,
                    HomeTeamId = m.HomeTeamId,
                    HomeTeamName = m.HomeTeam.Name,
                    HomeTeamImageUrl = m.HomeTeam.ImageUrl,
                    AwayTeamId = m.AwayTeamId,
                    AwayTeamName = m.AwayTeam.Name,
                    AwayTeamImageUrl = m.AwayTeam.ImageUrl,
                    Date = m.Date,
                    HomeScore = m.HomeScore,
                    AwayScore = m.AwayScore,
                    StadiumName = m.Stadium.Name,
                    Status = m.Status,
                    IsPlayed=m.Status == MatchStatus.Played,


                })
                .ToListAsync();

            return matches;
        }

        public async Task<MatchDetailsViewModel?> GetMatchDetailsAsync(long? id)
        {
            MatchDetailsViewModel? match = null;
            if (id.HasValue)
            {
                match = await this.matchRepository
                    .GetAllAttached()
                    .Include(m => m.HomeTeam)
                    .Include(m => m.AwayTeam)
                    .Include(m => m.League)
                    .Include(m => m.Stadium)
                    .AsNoTracking()
                    .Where(m => m.Id == id.Value)
                    .Select(m => new MatchDetailsViewModel
                    {
                        HomeTeamName = m.HomeTeam.Name,
                        HomeTeamImageUrl = m.HomeTeam.ImageUrl,
                        AwayTeamName = m.AwayTeam.Name,
                        AwayTeamImageUrl = m.AwayTeam.ImageUrl,
                        Date = m.Date,
                        HomeScore = m.HomeScore,
                        AwayScore = m.AwayScore,
                        StadiumName = m.Stadium.Name,
                        LeagueName = m.League.Name,
                        IsPlayed= m.Status == MatchStatus.Played,
                    })
                    .FirstOrDefaultAsync();
            }
            return match;
        }
    }
}
