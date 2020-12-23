namespace GiffyCards.Web.ViewModels
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Strenghts;

    public class StrenghtsList
    {
        public IEnumerable<StrnghtsViewModel> StrenghtsLists { get; set; }

        public StrnghtsViewModel CurrentStreght { get; set; }

        public IEnumerable<CigarWithBrandViewModel> Cigars { get; set; }
    }
}
