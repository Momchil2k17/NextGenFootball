using Microsoft.AspNetCore.Mvc;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core;
using NextGenFootball.Services.Core.Interfaces;

namespace NextGenFootball.Web.Controllers
{
    public class SearchController : BaseController
    {

        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Autocomplete(string q)
        {
            var results = await this.searchService.AutocompleteAsync(q);

            var mapped = results.Select(item => new
            {
                type = item.Type,
                name = item.Name,
                imageUrl=item.ImageUrl,
                url = item.Type == "Player"
                    ? Url.Action("Details", "Player", new { id = item.PlayerId })
                    : Url.Action("Details", "Team", new { id = item.TeamId })

            });

            return Json(mapped);
        }
    }
}
