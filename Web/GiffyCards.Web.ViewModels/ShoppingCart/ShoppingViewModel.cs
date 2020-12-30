namespace GiffyCards.Web.ViewModels.ShoppingCart
{
   public class ShoppingViewModel
    {
        public int CigarId { get; set; }

        public string ImageUrl { get; set; }

        public string CigarName { get; set; }

        public string CigarShape { get; set; }

        public int? Quantity { get; set; }

        public decimal PriceForSingle { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
