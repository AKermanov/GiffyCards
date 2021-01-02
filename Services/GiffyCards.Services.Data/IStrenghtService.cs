namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Strenghts;

    public interface IStrenghtService
    {
        IEnumerable<T> AllStrenghts<T>();

        StrnghtsViewModel CurrentStrenght(int id);
    }
}
