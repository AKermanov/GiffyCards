namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Common;
    using GiffyCards.Data.Models;

    public class CigarStrenghtSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Strenghts.Any())
            {
                return;
            }

            var list = new List<Strenght>();

            for (int i = 0; i < CigarSeedDataConstants.StrenghtList.Length; i++)
            {
                var curr = CigarSeedDataConstants.StrenghtList[i];
                var currentStrenght = new Strenght
                {
                    StrenghtType = curr,
                    PictureUrl = CigarSeedDataConstants.StrengthPictures[curr],
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                var str = list.FirstOrDefault(x => x.StrenghtType == currentStrenght.StrenghtType);

                if (str is null)
                {
                    list.Add(currentStrenght);
                }
            }

            await dbContext.Strenghts.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
        }
    }
}
