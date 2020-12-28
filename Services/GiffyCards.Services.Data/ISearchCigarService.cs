namespace GiffyCards.Services.Data
{
    using GiffyCards.Web.ViewModels.Brands;
    using System.Collections.Generic;

    public interface ISearchCigarService
    {
        IEnumerable<CigarWithBrandViewModel> CigarSearch(string input);
    }
}
