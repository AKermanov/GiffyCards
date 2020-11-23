using GiffyCards.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiffyCards.Data.Seeding
{
    public class CigarTasteSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Strenghts.Any())
            {
                return;
            }

            var taste = new string[] { "SPICY", "WOODY", "LEATHERLY", "VEGETAL", "EARTHY", "FRUTY" };

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
