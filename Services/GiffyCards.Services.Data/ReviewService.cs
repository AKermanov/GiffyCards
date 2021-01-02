namespace GiffyCards.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;
    using GiffyCards.Web.ViewModels.Reviews;

    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IRepository<ApplicationUser> userRepository;

        public ReviewService(IRepository<Review> reviewRepository, IRepository<ApplicationUser> userRepository)
        {
            this.reviewRepository = reviewRepository;
            this.userRepository = userRepository;
        }

        public async Task DeleteReview(int id)
        {
            var currentReview = this.reviewRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);

            this.reviewRepository.Delete(currentReview);
            await this.reviewRepository.SaveChangesAsync();
        }

        public async Task EditReview(EditReviewInputModel model)
        {
            var currentReview = this.reviewRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == model.Id);

            currentReview.ReviewText = model.ReviewText;
            await this.reviewRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetUserReviews<T>(string userId)
        {
            var user = this.userRepository.All().FirstOrDefault(i => i.Id == userId);
            var email = user.Email;
            var reviews = this.reviewRepository.AllAsNoTracking().Where(x => x.Email == email).To<T>().ToList();

            return reviews;
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
