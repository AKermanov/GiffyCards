namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class StrenghtsController : Controller
    {

        private readonly IStrenghtService strenghtsService;
        private readonly ICigarService cigarService;

        public StrenghtsController(IStrenghtService strenghtsService, ICigarService cigarService)
        {
            this.strenghtsService = strenghtsService;
            this.cigarService = cigarService;
        }

        public IActionResult ShowAllStrenghts()
        {
            var viewModel = new StrenghtsList
            {
                StrenghtsLists = this.strenghtsService.AllStrenghts(),
            };

            return this.View(viewModel);
        }

        public IActionResult ShowCigarWithStrength(int id)
        {
            var viewOutput = new StrenghtsList
            {
                Cigars = this.cigarService.CigaraWithStrenght(id),
                CurrentStreght = this.strenghtsService.CurrentStrenght(id),
            };

            return this.View(viewOutput);
        }

        public IActionResult CigarById(int id)
        {
            return this.Redirect($"/Brands/CigarById/{id}");
        }
    }
}
