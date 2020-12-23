namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.Cigar;
    using Microsoft.AspNetCore.Mvc;

    public class CigarsController : Controller
    {
        private readonly ICigarService cigarService;

        public CigarsController(ICigarService cigarService)
        {
            this.cigarService = cigarService;
        }

        public IActionResult AllCigars()
        {
            var all = new AllCIgarsViewModel
            {
                All = this.cigarService.AllCigars(),
            };

            return this.View(all);
        }
    }
}
