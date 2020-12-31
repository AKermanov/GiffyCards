namespace GiffyCards.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.Pictures;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class UsersPicturesController : Controller
    {
        private readonly IPictureService pictureService;
        private readonly IWebHostEnvironment environment;

        public UsersPicturesController(IPictureService pictureService, IWebHostEnvironment environment)
        {
            this.pictureService = pictureService;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult AllPictures()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var pics = new AllPicturesViewModel
            {
                CustomersPictures = this.pictureService.UsersPicture(userId),
            };

            return this.View(pics);
        }

        [Authorize]
        public IActionResult UploadPicture()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadPicture(CreatePictureInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await this.pictureService.CreateAsync(input, userId, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            this.TempData["Message"] = "Picture added successfully.";

            return this.RedirectToAction("AllPictures");
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeletePicture(string pictureId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.pictureService.DeletePicture(pictureId, userId);

            return this.RedirectToAction("AllPictures");
        }
    }
}
