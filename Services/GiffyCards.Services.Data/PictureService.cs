namespace GiffyCards.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Pictures;

    public class PictureService : IPictureService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<CustomerPhoto> photosEntity;

        public PictureService(IDeletableEntityRepository<CustomerPhoto> photosEntity)
        {
            this.photosEntity = photosEntity;
        }

        public async Task CreateAsync(CreatePictureInputModel input, string userId, string imagePath)
        {
            // /wwwroot/images/recipes/jhdsi-343g3h453-=g34g.jpg
            Directory.CreateDirectory($"{imagePath}/recipes/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new CustomerPhoto
                {
                    UserId = userId,
                    Extension = extension,
                    CigarId = input.CigarId,
                    PhotoText = input.PhotoText,
                };

                await this.photosEntity.AddAsync(dbImage);

                var physicalPath = $"{imagePath}/CustomerPhotos/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.photosEntity.SaveChangesAsync();
        }

        public async Task DeletePicture(string pictureId, string userId)
        {
            var pic = this.photosEntity.AllAsNoTracking().FirstOrDefault(x => x.Id == pictureId && x.UserId == userId);

            this.photosEntity.HardDelete(pic);
            await this.photosEntity.SaveChangesAsync();
        }

        public IEnumerable<DisplayPictureViewModel> GetAllPictures()
        {
            return this.photosEntity.AllAsNoTracking().OrderByDescending(x => x.CreatedOn).Select(x => new DisplayPictureViewModel
            {
                PictureId = x.Id,
                PhotoText = x.PhotoText,
                ImageUrl = "/images/CustomerPhotos/" + x.Id + "." + x.Extension,
            }).ToList();
        }

        public IEnumerable<DisplayPictureViewModel> UsersPicture(string userId)
        {
            return this.photosEntity
                .AllAsNoTracking()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.UserId == userId)
                .Select(x => new DisplayPictureViewModel
                {
                    PictureId = x.Id,
                    PhotoText = x.PhotoText,
                    ImageUrl = "/images/CustomerPhotos/" + x.Id + "." + x.Extension,
                }).ToList();
        }
    }
}
