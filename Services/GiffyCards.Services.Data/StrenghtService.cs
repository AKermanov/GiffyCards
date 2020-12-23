namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Strenghts;

    public class StrenghtService : IStrenghtService
    {
        private readonly IDeletableEntityRepository<Strenght> strenght;

        public StrenghtService(IDeletableEntityRepository<Strenght> strenghtRepository)
        {
            this.strenght = strenghtRepository;
        }

        public IEnumerable<StrnghtsViewModel> AllStrenghts()
        {
            return this.strenght.AllAsNoTracking().Select(x => new StrnghtsViewModel
            {
                Id = x.Id,
                StrenghtType = x.StrenghtType.ToUpper(),
                ImageUrl = x.PictureUrl,
            }).ToList();
        }

        public StrnghtsViewModel CurrentStrenght(int id)
        {
            return this.strenght.AllAsNoTracking().Select
                 (x => new StrnghtsViewModel
                 {
                     Id = x.Id,
                     ImageUrl = x.PictureUrl,
                     StrenghtType = x.StrenghtType,
                 })
                 .FirstOrDefault(x => x.Id == id);
        }
    }
}
