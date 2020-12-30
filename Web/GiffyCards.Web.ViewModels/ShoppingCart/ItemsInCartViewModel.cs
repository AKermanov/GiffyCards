namespace GiffyCards.Web.ViewModels.ShoppingCart
{
    using System.Collections.Generic;

    public class ItemsInCartViewModel
    {
       public IEnumerable<ShoppingViewModel> ItemsInCart { get; set; }

       public decimal OrderTotal { get; set; }
    }
}
