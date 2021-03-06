﻿namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public int? ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
