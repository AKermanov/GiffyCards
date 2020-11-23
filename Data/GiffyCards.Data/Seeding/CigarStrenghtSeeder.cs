using GiffyCards.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiffyCards.Data.Seeding
{
    public class CigarStrenghtSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Strenghts.Any())
            {
                return;
            }

            var strenght = new string[] { "Light", "Light-Medium", "Medium", "Medium-Full", "Full" };

            for (int i = 0; i < strenght.Length; i++)
            {
                var currStrenght = new Strenght
                {
                    StrenghtType = strenght[i],
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };
                dbContext.Strenghts.Add(currStrenght);
            }

            dbContext.SaveChanges();
        }
    }
}
