namespace GiffyCards.Data.Models
{
    using System;
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class ShoppingCart : BaseDeletableModel<string>
    {
        public ShoppingCart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int? AccessorieId { get; set; }

        public virtual Accessorie Accessorie { get; set; }

        public int? CigarId { get; set; }

        public virtual Cigar Cigar { get; set; }

        public int? QuantityForSingle { get; set; }

        public decimal? PriceForSingle { get; set; }

        public int? QuantityForBox { get; set; }

        public decimal? PriceForBox { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
