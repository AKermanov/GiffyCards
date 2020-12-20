namespace GiffyCards.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SizesController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult GetBySize(string shape)
        {
            return this.View();
        }
    }
}
