using GiffyCards.Services.Data;
using GiffyCards.Web.ViewModels.Search;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GiffyCards.Web.Controllers
{
    public class SearchCigarController : Controller
    {
        private readonly ISearchCigarService searchCigarService;

        public SearchCigarController(ISearchCigarService searchCigarService)
        {
            this.searchCigarService = searchCigarService;
        }

        [HttpGet]
        public IActionResult Search(string input)
        {
            var output = new SearchViewModel
            {
                SearchResult = this.searchCigarService.CigarSearch(input),
                SearchWord = input,
            };

            return this.View(output);
        }

    }
}
