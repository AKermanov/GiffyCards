namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GiffyCards.Web.ViewModels.Pictures;

    public interface IPictureService
    {
        Task CreateAsync(CreatePictureInputModel input, string userId, string imagePath);

        IEnumerable<DisplayPictureViewModel> GetAllPictures();

        IEnumerable<DisplayPictureViewModel> UsersPicture(string userId);

        Task DeletePicture(string pictureId, string userId);
    }
}
