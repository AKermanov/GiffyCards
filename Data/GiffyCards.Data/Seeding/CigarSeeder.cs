using GiffyCards.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiffyCards.Data.Seeding
{
    public class CigarSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cigars.Any())
            {
                return;
            }

            var cigarNameList = new string[] { "BOLIVAR CORONAS JUNIOR", "BOLIVAR PETIT CORONAS", "BOLIVAR ROYAL CORONAS", "COHIBA 1966 EDICION LIMITADA 2011- NO DISCOUNTS APPLY", "COHIBA BEHIKE 52",
            "COHIBA BEHIKE 54", "COHIBA BEHIKE 56" };
            var unitPrice = new decimal[] { 8.00m, 9.00m, 12.50m, 337.00m, 175.00m, 169.00m, 194.00m };
            var lengthRangeList = new string[] { "4", "5", "4", "6", "4", "5", "6" };
            var ringRangeList = new string[] { "42", "42", "50", "52", "52", "54", "56" };
            var shapeList = new string[] { "Corona", "Petit Corona", "Robusto", "Double Robusto", "Petit Robusto", "Robusto Extra", "Double Robusto" };
            var testeList = new string[] { "Earthy", "Earthy", "Spicy", "Spicy", "Woody", "Woody", "Woody" };
            var strenghtList = new string[] { "Full", "Medium to Full", "Medium to Full", "Medium to Full", "Medium to Full", "Medium to Full", "Full" };

            var list = new List<Cigar>();

            for (int i = 0; i < cigarNameList.Length; i++)
            {
                string brandName = cigarNameList[i].Split(" ")[0];

                var cigar = new Cigar
                {
                    Brand = BrandFinder(dbContext, brandName),
                    Strenght = StrenghtFinder(dbContext, strenghtList[i]),
                    Size = SizeFinder(lengthRangeList[i], ringRangeList[i]),
                    Taste = TasteFinder(dbContext, testeList[i]),
                    Shape = ShapeFinder(dbContext, shapeList[i]),
                    CigarName = cigarNameList[i],
                    Bland = "regular",
                    PricePerUnit = unitPrice[i],

                };

                list.Add(cigar);
            }
            dbContext.AddRange(list);
            dbContext.SaveChanges();
        }

        private static Size SizeFinder(string lenght, string ringRange)
        {
            return new Size
            {
                Lenght = lenght,
                RingRange = ringRange,
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,

            };
        }

        private static Shape ShapeFinder(ApplicationDbContext dbContext, string shape)
        {
            var currShape = dbContext.Shapes.FirstOrDefault(x => x.ShapeName.ToLower() == shape.ToLower());

            if (currShape is null)
            {
                return new Shape
                {
                    ShapeName = shape.ToLower(),
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };
            }

            return currShape;
        }

        private static Taste TasteFinder(ApplicationDbContext dbContext, string taste)
        {
            return dbContext.Tastes.FirstOrDefault(x => x.TasteType == taste.ToLower());
        }

        private static Strenght StrenghtFinder(ApplicationDbContext dbContext, string strength)
        {
            var strngth = dbContext.Strenghts.FirstOrDefault(x => x.StrenghtType == strength);

            if (strength is null)
            {
                return new Strenght
                {
                    StrenghtType = strength,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };
            }

            return strngth;
        }

        private static Brand BrandFinder(ApplicationDbContext dbContext, string brand)
        {
            return dbContext.Brands.FirstOrDefault(x => x.BrandName.ToLower() == brand.ToLower());
        }
    }
}
