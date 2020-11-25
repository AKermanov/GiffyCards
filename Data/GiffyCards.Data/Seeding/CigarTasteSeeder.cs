namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using GiffyCards.Data.Models;

    public class CigarTasteSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Strenghts.Any())
            {
                return;
            }

            var taste = new string[] { "spicy", "woody", "leatherly", "vegetal", "earthy", "fruty" };

            for (int i = 0; i < taste.Length; i++)
            {
                var currentTaste = new Taste
                {
                    TasteType = taste[i],
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                dbContext.Add(currentTaste);
            }

            dbContext.SaveChanges();
        }
    }
}
