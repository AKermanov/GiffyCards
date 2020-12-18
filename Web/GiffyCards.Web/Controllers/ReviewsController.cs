namespace GiffyCards.Web.Controllers
{
    using System.Threading.Tasks;

    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public IActionResult AddReview()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(ReviewInputModel reviewInputModel)
        {
            await this.reviewService.SetRevewAsync(reviewInputModel);

            return this.Redirect($"/Brands/CigarById/{reviewInputModel.CigarId}");
        }
    }
}
