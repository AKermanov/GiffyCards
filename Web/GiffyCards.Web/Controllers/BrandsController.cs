namespace GiffyCards.Web.Controllers
{
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;
    using GiffyCards.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BrandsController : Controller
    {
        private readonly IBrandService brandService;
        private readonly ICigarService cigarService;
        private readonly IReviewService reviewService;

        public BrandsController(IBrandService brandService, ICigarService cigarService, IReviewService reviewService)
        {
            this.brandService = brandService;
            this.cigarService = cigarService;
            this.reviewService = reviewService;
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

        [HttpPost]
        public async Task<ActionResult> CigarById(ReviewInputModel reviewInputModel)
        {
            await this.reviewService.SetRevewAsync(reviewInputModel);

            return this.View();
        }
    }
}
