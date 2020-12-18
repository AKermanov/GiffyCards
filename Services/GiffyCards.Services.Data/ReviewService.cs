namespace GiffyCards.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Reviews;

    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> reviewRepository;

        public ReviewService(IRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public async Task SetRevewAsync(ReviewInputModel reviewsViewModel)
        {
            var review = this.reviewRepository.All().FirstOrDefault(x => x.CigarId == reviewsViewModel.CigarId && x.Name == reviewsViewModel.Name);

            if (review == null)
            {
                review = new Review
                {
                    CigarId = reviewsViewModel.CigarId,
                    Name = reviewsViewModel.Name,
                    ReviewText = reviewsViewModel.Review,
                    Email = reviewsViewModel.Email,
                    Score = reviewsViewModel.Score,
                    CreatedOn = DateTime.UtcNow,
                };

            }
            try
            {
                await this.reviewRepository.AddAsync(review);
                await this.reviewRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
          
        }
    }
}
