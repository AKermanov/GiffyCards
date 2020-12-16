namespace GiffyCards.Web.Controllers
{
    using System.Threading.Tasks;

    using GiffyCards.Services.Data;
    using GiffyCards.Web.ViewModels.Cigar;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : BaseController
    {
        private readonly IReviewService reviewService;

        public ReviewController()
        {
            this.reviewService = reviewService;
        }

      
    }
}
