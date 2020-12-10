namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Home;

    public interface IdisplayHomePageService
    {
        IEnumerable<CigarsHeroItemViewModel> GetAllStores();
    }
}
