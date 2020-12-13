namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Home;

    public interface ICigarService
    {
       IEnumerable<CigarsHeroItemViewModel> GetWeaklySpecial();
    }
}
