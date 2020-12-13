using GiffyCards.Services.Data;
using GiffyCards.Web.ViewModels.Brands;
using Microsoft.AspNetCore.Mvc;

namespace GiffyCards.Web.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
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
    }
}
