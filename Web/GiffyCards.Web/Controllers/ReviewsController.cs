namespace GiffyCards.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.Cigar;
    using GiffyCards.Web.ViewModels.Reviews;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ReviewsController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [Authorize]
        public IActionResult AddReview()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddReview(ReviewInputModel reviewInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.reviewService.SetRevewAsync(reviewInputModel);

            return this.Redirect($"/Brands/CigarById/{reviewInputModel.CigarId}");
        }

        [Authorize]
        public IActionResult MyReviews()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var output = new UsersReviewsListModel
            {
                ReviewList = this.reviewService.GetUserReviews<ReviewsViewModel>(userId),
            };

            return this.View(output);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await this.reviewService.DeleteReview(id);
            return this.Redirect("MyReviews");
        }

        [Authorize]
        public IActionResult EditReview()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(EditReviewInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.reviewService.EditReview(model);

            return this.Redirect("/Reviews/MyReviews");
        }
    }
}
