namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Models;

    public class CigareSizeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Sizes.Any())
            {
                return;
            }

            var shapes = new string[] { "Giant", "Double Corona", "Chirchill", "Torpedo", "Toro", "Robusto", "Lonsdale", "Corona", "Panetela", "Cigarillos" };
            var lenghtRange = new string[] {"9",  "7.5 - 8", "7", "6.5 - 7", "5 - 6", "4 - 5",  "6.5 - 7", "5 - 6.5", "5 - 6", "3 - 4" };
            var reigRange = new string[] {"47 - 55",  "49 - 57", "47", "48 - 54", "46 - 60", "48 - 52",  "42 - 44", "42 - 46", "33 - 38", "20 - 22" };
            var list = new List<Size>();

            for (int i = 0; i < shapes.Length; i++)
            {
                var size = new Size
                {
                    Shape = shapes[i],
                    Lenght = lenghtRange[i],
                    RingRange = reigRange[i],
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                list.Add(size);
            }

            dbContext.Sizes.AddRange(list);
            dbContext.SaveChanges();
        }
    }
}
