namespace GiffyCards.Web.ViewModels.Cigar
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateCigarInputModel
    {
        public int BrandId { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string CigarName { get; set; }

        public int StrenghtId { get; set; }

        public int TasteId { get; set; }

        public int SizeId { get; set; }

        public string Bland { get; set; }

        public string Description { get; set; }

        public int ShapeId { get; set; }

        public decimal PricePerUnit { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BrandItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> StrenghtItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TasteItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> SizeItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ShapeItems { get; set; }
    }
}
