namespace GiffyCards.Web.ViewModels.Reviews
{
    using System.ComponentModel.DataAnnotations;

    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;

    public class ReviewInputModel
    {
        [Range(1, 5)]
        public byte Score { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Review { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int? CigarId { get; set; }

        public int AccessorieId { get; set; }
    }
}
