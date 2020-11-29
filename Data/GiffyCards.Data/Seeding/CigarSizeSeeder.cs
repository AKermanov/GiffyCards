namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Common;
    using GiffyCards.Data.Models;

   public class CigarSizeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sizes.Any())
            {
                return;
            }

            var list = new List<Size>();

            for (int i = 0; i < CigarSeedDataConstants.RingRangeList.Length; i++)
            {
                string ringRange = CigarSeedDataConstants.RingRangeList[i];
                string lenghtRange = CigarSeedDataConstants.LengthRangeList[i];

                var currentSize = new Size
                {
                    RingRange = ringRange,
                    Lenght = lenghtRange,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                var size = list.FirstOrDefault(x => x.RingRange == ringRange && x.Lenght == lenghtRange);

                if (size is null)
                {
                    list.Add(currentSize);
                }
            }

            dbContext.Sizes.AddRange(list);
            dbContext.SaveChanges();
        }

        
    }
}
