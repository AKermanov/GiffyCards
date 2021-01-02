namespace GiffyCards.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.ShoppingCart;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        [Authorize]
        public IActionResult Cart()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var items = this.shoppingCartService.GetAllByUser(userId);

            var output = new ItemsInCartViewModel
            {
                ItemsInCart = items,
                OrderTotal = this.shoppingCartService.OrdarTotal(items),
            };

            return this.View(output);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantutyForSingle)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.shoppingCartService.AddProduct(productId, userId, quantutyForSingle);
            return this.Redirect("Cart");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cigarId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.shoppingCartService.RemoveFromCart(cigarId, userId);

            return this.Redirect("Cart");
        }
    }
}
