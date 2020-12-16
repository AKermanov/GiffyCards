namespace GiffyCards.Services.Data
{
    using System.Threading.Tasks;

    using GiffyCards.Web.ViewModels.Reviews;

    public interface IReviewService
    {
        Task SetRevewAsync(ReviewInputModel reviewsViewModel);
    }
}
