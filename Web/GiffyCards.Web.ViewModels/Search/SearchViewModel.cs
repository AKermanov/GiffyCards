namespace GiffyCards.Web.ViewModels.Search
{
    using System.Collections.Generic;
    using GiffyCards.Web.ViewModels.Brands;

    public class SearchViewModel
    {
       public IEnumerable<CigarWithBrandViewModel> SearchResult { get; set; }

       public string SearchWord { get; set; }
    }
}
