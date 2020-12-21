namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Sizes;

    public class SizeService : ISizeService
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepository;

        public SizeService(IDeletableEntityRepository<Cigar> cigarRepository)
        {
            this.cigarRepository = cigarRepository;
        }

        public IEnumerable<ShapeAndSizeViewModel> GetAllShapesAndSizes()
        {
            var list = this.cigarRepository.AllAsNoTracking().Select(x => new ShapeAndSizeViewModel
            {
                ShapeName = x.Shape.ShapeName,
                Id = x.ShapeId.GetValueOrDefault(),
                Lenght = x.Size.Lenght,
                RingRange = x.Size.RingRange,
            })
              .ToList();

            return list.Distinct();
        }
    }
}
