namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GiffyCards.Common;
    using GiffyCards.Data.Models;

    public class CigarTasteSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Tastes.Any())
            {
                return;
            }

            var list = new List<Taste>();

            for (int i = 0; i < CigarSeedDataConstants.TesteList.Length; i++)
            {

                var tasteType = CigarSeedDataConstants.TesteList[i].Trim();

                var currentTaste = new Taste
                {
                    TasteType = tasteType,
                    ImageUrl = CigarSeedDataConstants.TastePictures[tasteType],
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                var taste = list.FirstOrDefault(x => x.TasteType == currentTaste.TasteType);

                if (taste is null)
                {
                    list.Add(currentTaste);
                }
            }

            await dbContext.Tastes.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
        }
    }
}
