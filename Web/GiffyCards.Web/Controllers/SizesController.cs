namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class SizesController : Controller
    {
        private readonly ISizeService sizeService;
        private readonly ICigarService cigarService;

        public SizesController(ISizeService sizeService, ICigarService cigarService)
        {
            this.sizeService = sizeService;
            this.cigarService = cigarService;
        }

        public IActionResult All()
        {
            var view = new SizesAllViewModel
            {
                ShapeAndSizeViewModel = this.sizeService.GetAllShapesAndSizes(),
            };

            return this.View(view);
        }

        public IActionResult GetBySize(int id)
        {
            var view = new SizesAllViewModel
            {
                CiagrWithSpesificShape = this.cigarService.CiagrWithSpesificShape(id),
            };

            return this.View(view);
        }

        public IActionResult CigarById(int id)
        {
            return this.Redirect($"/Brands/CigarById/{id}");
        }
    }
}
