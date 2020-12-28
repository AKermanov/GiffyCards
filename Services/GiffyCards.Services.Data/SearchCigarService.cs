namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;

    public class SearchCigarService : ISearchCigarService
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepository;

        public SearchCigarService(IDeletableEntityRepository<Cigar> cigarRepository)
        {
            this.cigarRepository = cigarRepository;
        }

        public IEnumerable<CigarWithBrandViewModel> CigarSearch(string input)
        {
            return this.cigarRepository.AllAsNoTracking().Where(x => x.CigarName.Contains(input) ||
           x.Brand.BrandName.Contains(input) ||
           x.Shape.ShapeName.Contains(input) ||
           x.Strenght.StrenghtType.Contains(input) ||
           x.Taste.TasteType.Contains(input))
               .Select(y => new CigarWithBrandViewModel
               {
                   Id = y.Id,
                   CiagrName = y.CigarName.Replace('-', ' '),
                   ImageUrl = y.ImageUrl,
                   PriceForSingle = $"Single - US$ {y.PricePerUnit:f2}",
                   PriceForBox = $"Box 25 - US$ {y.PricePerUnit * 23:f2}",
               }).ToList();
        }
    }
}
