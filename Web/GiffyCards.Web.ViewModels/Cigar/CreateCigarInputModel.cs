namespace GiffyCards.Web.ViewModels.Cigar
{
    using GiffyCards.Data.Models;

    public class CreateCigarInputModel
    {
        public int BrandId { get; set; }

        public string CigarName { get; set; }

        public int StrenghtId { get; set; }

        public int TasteId { get; set; }

        public int SizeId { get; set; }

        public string Bland { get; set; }

        public string Description { get; set; }

        public int ShapeId { get; set; }

        public decimal PricePerUnit { get; set; }

        public string ImageUrl { get; set; }
    }
}
