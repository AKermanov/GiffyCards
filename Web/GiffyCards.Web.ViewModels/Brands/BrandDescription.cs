namespace GiffyCards.Web.ViewModels.Brands
{
    using System.Collections.Generic;

    public class BrandDescription
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<CigarWithBrandViewModel> Cigars { get; set; }
    }
}
