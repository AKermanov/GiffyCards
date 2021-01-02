namespace GiffyCards.Web.ViewModels.Reviews
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Cigar;

    public class UsersReviewsListModel
    {
        public IEnumerable<ReviewsViewModel> ReviewList { get; set; }
    }
}
