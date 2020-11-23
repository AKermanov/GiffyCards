namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Address : BaseDeletableModel<int>
    {
        public Address()
        {
            this.Orders = new HashSet<Order>();
        }

        public string Town { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string Street { get; set; }

        public string OtherAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
