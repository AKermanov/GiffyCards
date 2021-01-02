namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;
    using GiffyCards.Web.ViewModels.Strenghts;

    public class StrenghtService : IStrenghtService
    {
        private readonly IDeletableEntityRepository<Strenght> strenght;

        public StrenghtService(IDeletableEntityRepository<Strenght> strenghtRepository)
        {
            this.strenght = strenghtRepository;
        }

        public IEnumerable<T> AllStrenghts<T>()
        {
            var all = this.strenght.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .To<T>()
                .ToList();

            return all;
        }

        public StrnghtsViewModel CurrentStrenght(int id)
        {
            return this.strenght.AllAsNoTracking().Select(
                 x => new StrnghtsViewModel
                 {
                     Id = x.Id,
                     PictureUrl = x.PictureUrl,
                     StrenghtType = x.StrenghtType,
                 })
                 .FirstOrDefault(x => x.Id == id);
        }
    }
}
