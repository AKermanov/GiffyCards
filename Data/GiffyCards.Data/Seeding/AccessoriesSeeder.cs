namespace GiffyCards.Data.Seeding
{
    using GiffyCards.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccessoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Accessories.Any())
            {
                return;
            }

            var acces = new string[] { "Adorini Double Punch Cutter - Made in Germany", "Adorini Hygrometer Compact - Made in Germany",
            "Adorini Hygrometer Digital - Made in Germany", "Adorini Jet Lighter - Made in Germany", "Pouch", "Xikar Ellipse III Lighter",
            "Xikar Envoy Triple Cigar Case - High Performance", "Xikar Flash Lighter", "Xikar Forte Lighter", "Xikar Turismo Double Lighter",
            "Xikar VX2 V-Cut Cutter",  "Xikar Xi1 Cigar Cutter", "Xikar Xi2 Cutter", "Xikar XO Cutter", };

            var price = new double[] { 43.00, 35.00, 39.00, 54.00, 3.00, 98.00, 103.00, 32.00, 77.00, 66.00, 55.00, 69.00, 49.00, 99.00 };

            var list = new List<Accessorie>();

            for (int i = 0; i < acces.Length; i++)
            {
                var curr = new Accessorie
                {
                    AccessorieName = acces[i],
                    PricePerUnit = (decimal)price[i],
                    IsDeleted = false,
                };

                list.Add(curr);
            }

            dbContext.AddRange(list);
            dbContext.SaveChanges();
        }
    }
}
