namespace GiffyCards.Web.ViewModels.Pictures
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreatePictureInputModel
    {
        public int? CigarId { get; set; }

        [MinLength(10)]
        [MaxLength(200)]
        public string PhotoText { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }
    }
}
