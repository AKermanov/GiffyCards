namespace GiffyCards.Web.ViewModels.Reviews
{
    using System.ComponentModel.DataAnnotations;

   public class ReviewInputModel
    {
        [Range(1, 5)]
        public byte Score { get; set; }

        [Required]
        [StringLength(1000)]
        public string ReviewText { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int? CigarId { get; set; }
    }
}
