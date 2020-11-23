namespace GiffyCards.Data.Models
{
    using GiffyCards.Data.Common.Models;

    public class ProductType : BaseDeletableModel<int>
    {
        public int? CigarId { get; set; }

        public Cigar Cigar { get; set; }

        public int? AccessoriesId { get; set; }

        public Accessorie Accessories { get; set; }
    }
}
