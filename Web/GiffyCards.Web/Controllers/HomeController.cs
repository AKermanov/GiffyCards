namespace GiffyCards.Web.Controllers
{
    using System.Diagnostics;

    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels;
    using GiffyCards.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICigarService cigarService;
        private readonly IPictureService pictureService;

        public HomeController(ICigarService cigarService, IPictureService pictureService)
        {
            this.cigarService = cigarService;
            this.pictureService = pictureService;
        }

        public IActionResult Index()
        {
            var viewModel = new DisplayHomePageViewModel
            {
                Cigars = this.cigarService.GetWeaklySpecial(),
                CustomerPictures = this.pictureService.GetAllPictures(),
            };

            return this.View(viewModel);
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

        public IActionResult CigarById(int id)
        {
            return this.Redirect($"/Brands/CigarById/{id}");
        }

        public IActionResult AboutUs()
        {
            return this.View();
        }
    }
}
