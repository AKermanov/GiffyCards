namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.Brands;
    using Microsoft.AspNetCore.Mvc;

    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;
        private readonly ICigarService cigarService;

        public BrandsController(IBrandService brandService, ICigarService cigarService)
        {
            this.brandService = brandService;
            this.cigarService = cigarService;
        }

        public IActionResult ShowAllBrands()
        {
            var viewModel = new BrandsList
            {
                Brands = this.brandService.GetAllBrands(),
            };

            return this.View(viewModel);
        }

        public IActionResult ShowCigarWithBrand(int id)
        {
            var output = this.brandService.GetBrand(id);

            return this.View(output);
        }

        public IActionResult CigarById(int id)
        {
            var view = this.cigarService.GetSingleCigarById(id);

            return this.View(view);
        }
    }
}
