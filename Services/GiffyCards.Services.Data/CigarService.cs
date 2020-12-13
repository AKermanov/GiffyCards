namespace GiffyCards.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Home;

    public class CigarService : ICigarService
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepository;

        public CigarService(IDeletableEntityRepository<Cigar> cigarRepository)
        {
            this.cigarRepository = cigarRepository;
        }

        public IEnumerable<CigarsHeroItemViewModel> GetWeaklySpecial()
        {
            return this.cigarRepository.AllAsNoTracking()
                .Take(5)
                .Select(x => new CigarsHeroItemViewModel
                {
                    Id = x.Id,
                    CigarName = x.CigarName,
                    Discount = Math.Round((x.PricePerUnit / 2) + 10).ToString("G29") + '%',
                    ImageUrl = x.ImageUrl,
                }).ToList();
        }
    }
}
