namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Common;
    using GiffyCards.Data.Models;

    public class AccessoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Accessories.Any())
            {
                return;
            }

            var acccs = AccessoriesConstants.Acces;
            var price = AccessoriesConstants.Price;

            var list = new List<Accessorie>();

            for (int i = 0; i < acccs.Length; i++)
            {
                var curr = new Accessorie
                {
                    AccessorieName = acccs[i],
                    PricePerUnit = (decimal)price[i],
                    IsDeleted = false,
                };

                list.Add(curr);
            }

            await dbContext.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
        }
    }
}
