namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Common;
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

        public IActionResult AllCigars(int id = 1)
        {
            var all = new AllCIgarsViewModel
            {
                ItemsPerPage = GlobalConstants.CigarsPerPage,
                PageNumber = id,
                CigarsCount = this.cigarService.GetCount(),
                All = this.cigarService.AllCigars(id, GlobalConstants.CigarsPerPage),
            };

            return this.View(all);
        }
    }
}
