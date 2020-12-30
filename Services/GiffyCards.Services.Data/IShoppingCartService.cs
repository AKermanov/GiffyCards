namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GiffyCards.Web.ViewModels.ShoppingCart;

    public interface IShoppingCartService
    {
        Task AddProduct(int productId, string userId, int quantityForSingle);

        IEnumerable<ShoppingViewModel> GetAllByUser(string userId);

        public decimal OrdarTotal(IEnumerable<ShoppingViewModel> input);

        Task RemoveFromCart(int id, string userId);
    }
}
