namespace GiffyCards.Web.ViewModels
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Tastes;

    public class TastesLists
    {
        public TastesViewModel CurrentTaste { get; set; }

        public IEnumerable<TastesViewModel> TastsLists { get; set; }

        public IEnumerable<CigarWithBrandViewModel> Cigars { get; set; }
    }
}
