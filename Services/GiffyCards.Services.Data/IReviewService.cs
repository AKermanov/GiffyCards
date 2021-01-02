namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GiffyCards.Web.ViewModels.Reviews;

    public interface IReviewService
    {
        Task SetRevewAsync(ReviewInputModel reviewsViewModel);

        IEnumerable<T> GetUserReviews<T>(string userId);

        Task DeleteReview(int id);

        Task EditReview(EditReviewInputModel model);
    }
}
