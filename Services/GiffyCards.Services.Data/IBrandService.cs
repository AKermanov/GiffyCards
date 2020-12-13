namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;

    public interface IBrandService
    {
        IEnumerable<BrandViewModel> GetAllBrands();

        BrandDescription GetBrand(int id);
    }
}
