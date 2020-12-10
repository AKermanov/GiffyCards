namespace GiffyCards.Services.Data
{
    using System;
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Home;

    public class DisplayHomePageService : IdisplayHomePageService
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepo;

        public DisplayHomePageService(IDeletableEntityRepository<Cigar> cigarRepo)
        {
            this.cigarRepo = cigarRepo;
        }

        public IEnumerable<CigarsHeroItemViewModel> GetAllStores()
        {
            var list = new List<CigarsHeroItemViewModel>();
            for (int i = 0; i < 5; i++)
            {
                var current = new CigarsHeroItemViewModel
                {
                    //Id = this.cigarRepo.AllAsNoTracking().

                };
            }

            return list;
        }
    }
}
