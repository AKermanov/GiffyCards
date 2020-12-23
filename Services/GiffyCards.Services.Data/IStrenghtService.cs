namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Strenghts;

    public interface IStrenghtService
    {
        IEnumerable<StrnghtsViewModel> AllStrenghts();

        StrnghtsViewModel CurrentStrenght(int id);
    }
}
