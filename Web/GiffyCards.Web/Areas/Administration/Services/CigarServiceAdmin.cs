namespace GiffyCards.Web.Areas.Administration.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;
    using Microsoft.EntityFrameworkCore;

    public class CigarServiceAdmin : ICigarServiceAdmin
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepository;
        private readonly IDeletableEntityRepository<Brand> brandsRepository;
        private readonly IDeletableEntityRepository<Shape> shapeRepository;
        private readonly IDeletableEntityRepository<Size> sizeRepository;
        private readonly IDeletableEntityRepository<Taste> tasteRepository;
        private readonly IDeletableEntityRepository<Strenght> strengthRepository;

        public CigarServiceAdmin(
            IDeletableEntityRepository<Cigar> cigarRepository,
            IDeletableEntityRepository<Brand> brandsRepository,
            IDeletableEntityRepository<Shape> shapeRepository,
            IDeletableEntityRepository<Size> sizeRepository,
            IDeletableEntityRepository<Taste> tasteRepository,
            IDeletableEntityRepository<Strenght> strengthRepository)
        {
            this.cigarRepository = cigarRepository;
            this.brandsRepository = brandsRepository;
            this.shapeRepository = shapeRepository;
            this.sizeRepository = sizeRepository;
            this.tasteRepository = tasteRepository;
            this.strengthRepository = strengthRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> BrandsAsKeyValuePairs()
        {
            return this.brandsRepository.All().Select(x => new { x.Id, x.BrandName })
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.BrandName));
        }

        public async Task CreateCigar(CreateCigarInputModel input)
        {
            var cigar = new Cigar
            {
               BrandId = input.BrandId,
               CigarName = input.CigarName,
               StrenghtId = input.StrenghtId,
               TasteId = input.TasteId,
               SizeId = input.SizeId,
               Bland = input.Bland,
               ShapeId = input.ShapeId,
               PricePerUnit = input.PricePerUnit,
               ImageUrl = input.ImageUrl,
            };

            await this.cigarRepository.AddAsync(cigar);
            await this.cigarRepository.SaveChangesAsync();
        }

        public Task<Cigar> DeleteCigar(int? id)
        {
           return this.cigarRepository.All().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteCigarConfirmed(int id)
        {
            var cigar = await this.cigarRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            this.cigarRepository.Delete(cigar);

            await this.cigarRepository.SaveChangesAsync();
        }

        public IEnumerable<SingleCigarViewModel> GetAll()
        {
            return this.cigarRepository.AllAsNoTracking().Select(x => new SingleCigarViewModel
            {
                Id = x.Id,
                Shape = x.Shape,
                Size = x.Size,
                Bland = x.Bland,
                Strenght = x.Strenght,
                Brand = x.Brand,
                CigarName = x.CigarName,
                Taste = x.Taste,
                PriceForSingle = x.PricePerUnit.ToString(),
                CreatedOn = x.CreatedOn,
            })
                .OrderByDescending(x => x.CreatedOn)
                .ToList();
        }

        public IEnumerable<KeyValuePair<string, string>> ShapeAsKeyValuePairs()
        {
            return this.shapeRepository.All().Select(x => new { x.Id, x.ShapeName })
                 .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.ShapeName));
        }

        public IEnumerable<KeyValuePair<string, string>> SizeAsKeyValuePairs()
        {
            return this.sizeRepository.All().Select(x => new { x.Id, x.RingRange })
                 .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.RingRange));
        }

        public IEnumerable<KeyValuePair<string, string>> StrengthAsKeyValuePairs()
        {
            return this.strengthRepository.All().Select(x => new { x.Id, x.StrenghtType })
                 .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.StrenghtType));
        }

        public IEnumerable<KeyValuePair<string, string>> TasteAsKeyValuePairs()
        {
            return this.tasteRepository.All().Select(x => new { x.Id, x.TasteType })
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.TasteType));
        }
    }
}
