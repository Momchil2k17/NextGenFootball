using Microsoft.EntityFrameworkCore;
using NextGenFootball.Data.Common.Search;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using static NextGenFootball.GCommon.ApplicationConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class SearchService : ISearchService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IPlayerRepository playerRepository;

        public SearchService(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            this.teamRepository = teamRepository;
            this.playerRepository = playerRepository;
        }

        public async Task<List<SearchResult>> AutocompleteAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query) || query.Length < 2)
                return new List<SearchResult>();

            var players = this.playerRepository
                .GetAllAttached()
                .Where(p => p.FirstName.Contains(query) || p.LastName.Contains(query)
                || (p.FirstName + " " + p.LastName).Contains(query))
                .Select(p => new SearchResult
                {
                    Type = "Player",
                    Name = p.FirstName + " " + p.LastName,
                    PlayerId = p.Id,
                    TeamId = null,
                    ImageUrl=p.ImageUrl ?? $"/images/{NoImagePeopleUrl}",
                })
                .Take(5);

            var teams = this.teamRepository
                .GetAllAttached()
                .Where(t => t.Name.Contains(query))
                .Select(t => new SearchResult
                {
                    Type = "Team",
                    Name = t.Name,
                    PlayerId = null,
                    TeamId = t.Id,
                    ImageUrl = t.ImageUrl ?? $"/images/{NoTeamImageUrl}",
                })
                .Take(5);

            var results = players.Concat(teams)
            .OrderBy(x => x.Name)
            .ToList();

            return await Task.FromResult(results);
        }
    }
}
