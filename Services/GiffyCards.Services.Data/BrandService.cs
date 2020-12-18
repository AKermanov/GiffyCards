namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Brands;

    public class BrandService : IBrandService
    {
        private readonly IDeletableEntityRepository<Brand> brandRepository;

        public BrandService(IDeletableEntityRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public IEnumerable<BrandViewModel> GetAllBrands()
        {
            return this.brandRepository.AllAsNoTracking().Select(x => new BrandViewModel
            {
                Id = x.Id,
                BrandName = x.BrandName.Replace('-', ' '),
                ImageUrl = x.BrandPictureUrl,
            }).ToList();
        }

        public BrandDescription GetBrand(int id)
        {
            return this.brandRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new BrandDescription
                {
                    Id = x.Id,
                    BrandName = x.BrandName.Replace('-', ' '),
                    Description = x.Description,
                    ImageUrl = x.BrandPictureUrl,
                    Cigars = x.Cigars.Where(j => j.BrandId == id)
                    .Select(y => new CigarWithBrandViewModel
                    {
                        Id = y.Id,
                        CiagrName = y.CigarName.Replace('-', ' '),
                        ImageUrl = y.ImageUrl,
                        PriceForSingle = $"Single - US$ {y.PricePerUnit:f2}",
                        PriceForBox = $"Box 25 - US$ {y.PricePerUnit * 23:f2}",
                    }).ToList(),
                })
                .FirstOrDefault();
        }
    }
}
