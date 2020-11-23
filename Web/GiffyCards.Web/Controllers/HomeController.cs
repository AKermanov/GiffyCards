namespace GiffyCards.Web.Controllers
{
    using System.Diagnostics;
    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        /*
        private readonly IStoreService storeService;

        public HomeController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        */
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
