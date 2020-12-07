namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Common;
    using GiffyCards.Data.Models;

    public class CigarBrandSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Brands.Any())
            {
                return;
            }

            var list = new List<Brand>();

            for (int i = 0; i < CigarSeedDataConstants.CigarNameList.Length; i++)
            {
                string brandName = CigarSeedDataConstants.CigarNameList[i].Split(" ")[0];

                var currentBrand = new Brand
                {
                    BrandName = brandName,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                var brand = list.FirstOrDefault(x => x.BrandName == currentBrand.BrandName);

                if (brand is null)
                {
                    list.Add(currentBrand);
                }
            }

            await dbContext.Brands.AddRangeAsync(list);
            await dbContext.AddRangeAsync();
        }
    }
}
