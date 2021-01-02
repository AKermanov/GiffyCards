namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;

    public interface ISearchCigarService
    {
        IEnumerable<CigarWithBrandViewModel> CigarSearch(string input);
    }
}
