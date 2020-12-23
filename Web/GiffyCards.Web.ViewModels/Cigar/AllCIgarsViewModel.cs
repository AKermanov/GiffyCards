namespace GiffyCards.Web.ViewModels.Cigar
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;

    public class AllCIgarsViewModel
    {
        public IEnumerable<CigarWithBrandViewModel> All { get; set; }
    }
}
