namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;
    using GiffyCards.Web.ViewModels.Tastes;

    public class TastesService : ITastesService
    {
        private readonly IDeletableEntityRepository<Taste> tasteRepository;

        public TastesService(IDeletableEntityRepository<Taste> tasteRepository)
        {
            this.tasteRepository = tasteRepository;
        }

        public IEnumerable<T> AllTastes<T>()
        {
            return this.tasteRepository.AllAsNoTracking().To<T>().ToList();
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
