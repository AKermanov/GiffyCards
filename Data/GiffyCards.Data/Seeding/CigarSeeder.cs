namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Common;
    using GiffyCards.Data.Models;

    public class CigarSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cigars.Any())
            {
                return;
            }

            var list = new List<Cigar>();

            for (int i = 0; i < CigarSeedDataConstants.CigarNameList.Length; i++)
            {
                string brandName = CigarSeedDataConstants.CigarNameList[i].Split(" ")[0];

                var cigar = new Cigar
                {
                    BrandId = BrandFinder(dbContext, brandName),
                    StrenghtId = StrenghtFinder(dbContext, CigarSeedDataConstants.StrenghtList[i]),
                    SizeId = SizeFinder(dbContext, CigarSeedDataConstants.LengthRangeList[i], CigarSeedDataConstants.RingRangeList[i]),
                    TasteId = TasteFinder(dbContext, CigarSeedDataConstants.TesteList[i]),
                    ShapeId = ShapeFinder(dbContext, CigarSeedDataConstants.ShapeList[i]),
                    CigarName = CigarSeedDataConstants.CigarNameList[i],
                    Bland = "regular",
                    PricePerUnit = CigarSeedDataConstants.UnitPrice[i],
                    ImageUrl = CigarSeedDataConstants.ImageUrl[i],

                };

                list.Add(cigar);
            }

            await dbContext.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
        }

        private static int SizeFinder(ApplicationDbContext dbContext, string lenght, string ringRange)
        {
            var currSize = dbContext.Sizes.FirstOrDefault(x => x.Lenght.ToLower() == lenght.ToLower() && x.RingRange.ToLower() == ringRange.ToLower());

            return currSize.Id;
        }

        private static int ShapeFinder(ApplicationDbContext dbContext, string shapeType)
        {
            var currShape = dbContext.Shapes.FirstOrDefault(x => x.ShapeName == shapeType);
            return currShape.Id;
        }

        private static int TasteFinder(ApplicationDbContext dbContext, string taste)
        {
            var currTaste = dbContext.Tastes.FirstOrDefault(x => x.TasteType == taste);
            return currTaste.Id;
        }

        private static int StrenghtFinder(ApplicationDbContext dbContext, string strength)
        {
            var currStr = dbContext.Strenghts.FirstOrDefault(x => x.StrenghtType == strength);
            return currStr.Id;
        }

        private static int BrandFinder(ApplicationDbContext dbContext, string brand)
        {
            var currTBrand = dbContext.Brands.FirstOrDefault(x => x.BrandName == brand);
            return currTBrand.Id;
        }
    }
}
