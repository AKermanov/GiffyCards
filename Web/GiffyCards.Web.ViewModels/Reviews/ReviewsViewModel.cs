namespace GiffyCards.Web.ViewModels.Cigar
{
    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;

    public class ReviewsViewModel : IMapFrom<Review>
    {
        public int Id { get; set; }

        public byte Score { get; set; }

        public string ReviewText { get; set; }

        public string Name { get; set; }

        public int? CigarId { get; set; }
    }
}
