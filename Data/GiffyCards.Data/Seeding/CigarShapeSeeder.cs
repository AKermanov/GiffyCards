namespace GiffyCards.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Common;
    using GiffyCards.Data.Models;

    public class CigarShapeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Shapes.Any())
            {
                return;
            }

            var list = new List<Shape>();

            for (int i = 0; i < CigarSeedDataConstants.ShapeList.Length; i++)
            {
                var name = CigarSeedDataConstants.ShapeList[i];
                var currentShape = new Shape
                {
                    ShapeName = name,
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                };

                var shape = list.FirstOrDefault(x => x.ShapeName == name);

                if (shape is null)
                {
                    list.Add(currentShape);
                }
            }

            await dbContext.Shapes.AddRangeAsync(list);
            await dbContext.SaveChangesAsync();
        }
    }
}
