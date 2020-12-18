namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Tastes;

    public interface ITastesService
    {
        IEnumerable<TastesViewModel> AllTastes();
    }
}
