namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Cigar : BaseDeletableModel<int>
    {
        public Cigar()
        {
            this.OrderProducts = new HashSet<OrderProducts>();
        }

        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public string CigarName { get; set; }

        public int? StrenghtId { get; set; }

        public virtual Strenght Strenght { get; set; }

        public int? TasteId { get; set; }

        public virtual Taste Taste { get; set; }

        public int? ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public int? SizeId { get; set; }

        public virtual Size Size { get; set; }

        public int? QuestionId { get; set; }

        public Question Question { get; set; }

        public string Bland { get; set; }

        public int? DescriptionId { get; set; }

        public Description Description { get; set; }

        public int? ShapeId { get; set; }

        public Shape Shape { get; set; }

        public decimal PricePerUnit { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
