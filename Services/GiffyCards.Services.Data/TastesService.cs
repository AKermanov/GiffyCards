namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Tastes;

    public class TastesService : ITastesService
    {
        private readonly IDeletableEntityRepository<Taste> tasteRepository;

        public TastesService(IDeletableEntityRepository<Taste> tasteRepository)
        {
            this.tasteRepository = tasteRepository;
        }

        public IEnumerable<TastesViewModel> AllTastes()
        {
            return this.tasteRepository.AllAsNoTracking().Select(x => new TastesViewModel
            {
                Id = x.Id,
                TasteType = x.TasteType.ToUpper(),
                ImageUrl = x.ImageUrl,
            }).ToList();
        }

        public TastesViewModel CurrentTaste(int id)
        {
           return this.tasteRepository.AllAsNoTracking().Select(
                x => new TastesViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    TasteType = x.TasteType,
                })
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
