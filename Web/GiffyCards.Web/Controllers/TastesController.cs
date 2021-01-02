namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels;
    using GiffyCards.Web.ViewModels.Tastes;
    using Microsoft.AspNetCore.Mvc;

    public class TastesController : Controller
    {
        private readonly ITastesService tastesService;
        private readonly ICigarService cigarService;

        public TastesController(ITastesService tastesService, ICigarService cigarService)
        {
            this.tastesService = tastesService;
            this.cigarService = cigarService;
        }

        public IActionResult AllTastes()
        {
            var viewModel = new TastesLists
            {
                TastsLists = this.tastesService.AllTastes<TastesViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult ShowCigarWithTaste(int id)
        {
            var viewOutput = new TastesLists
            {
                Cigars = this.cigarService.CigaraWithTaste(id),
                CurrentTaste = this.tastesService.CurrentTaste(id),
            };

            return this.View(viewOutput);
        }

        public IActionResult CigarById(int id)
        {
            return this.Redirect($"/Brands/CigarById/{id}");
        }
    }
}
