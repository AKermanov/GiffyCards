using GiffyCards.Data.Common.Models;

namespace GiffyCards.Data.Models
{
    public class OrderProducts : BaseDeletableModel<int>
    {
        public int? OrderId { get; set; }

        public Order Orders { get; set; }

        public int? ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
    }
}
