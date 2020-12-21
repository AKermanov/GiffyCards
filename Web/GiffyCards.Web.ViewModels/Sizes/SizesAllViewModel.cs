namespace GiffyCards.Web.ViewModels
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Sizes;

    public class SizesAllViewModel
    {
       public IEnumerable<ShapeAndSizeViewModel> ShapeAndSizeViewModel { get; set; }

       public IEnumerable<CigarWithBrandViewModel> CiagrWithSpesificShape { get; set; }
    }
}
