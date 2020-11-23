namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Models;

    public class CigarBrandSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Brands.Any())
            {
                return;
            }

            var brands = new string[] {"Bolivar", "Cohiba", "Cuaba", "Diplomaticos", "El Rey Del Mundo", "Fonseca" , "Hoyo de Monterrey",
            "H. Upman", "Jose L. Piedra", "Juan Lopez", "La Gloria Cubana", "Montecristo", "Partagas", "Punch", "Quai Dorsay", "Quintero",
            "Ramon Allones", "Romei y Julieta", "San Cristobal", "Trinidad", "Vegas Robain", "Vegueros", "Davidoff (non-Cuban)", "Limited Editions", };

            var list = new List<Brand>();

            for (int i = 0; i < brands.Length; i++)
            {
                var current = new Brand
                {
                    BrandName = brands[i],
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                list.Add(current);
            }

            dbContext.AddRange(list);
            dbContext.SaveChanges();
        }
    }
}
