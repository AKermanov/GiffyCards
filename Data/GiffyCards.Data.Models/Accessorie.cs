namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Accessorie : BaseDeletableModel<int>
    {
        public Accessorie()
        {
            this.OrderProducts = new HashSet<OrderProducts>();
            this.Reviews = new HashSet<Review>();
        }

        public string AccessorieName { get; set; }

        public int? DescriptionId { get; set; }

        public virtual Description Description { get; set; }

        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public decimal? PricePerUnit { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<OrderProducts> OrderProducts { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
