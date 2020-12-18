namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class TastesController : Controller
    {
        private readonly ITastesService tastesService;

        public TastesController(ITastesService tastesService)
        {
            this.tastesService = tastesService;
        }

        public IActionResult AllTastes()
        {
            var viewModel = new TastesLists
            {
                TastsLists = this.tastesService.AllTastes(),
            };

            return this.View(viewModel);
        }
    }
}
