namespace GiffyCards.Web.ViewModels.Cigar
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewsViewModel
    {
        public byte Score { get; set; }

        public string ReviewText { get; set; }

        public string Name { get; set; }

        public int? CigarId { get; set; }
    }
}
