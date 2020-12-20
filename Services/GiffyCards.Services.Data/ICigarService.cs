namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;
    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;
    using GiffyCards.Web.ViewModels.Home;

    public interface ICigarService
    {
        IEnumerable<CigarsHeroItemViewModel> GetWeaklySpecial();

        SingleCigarViewModel GetSingleCigarById(int id);

        IEnumerable<CigarWithBrandViewModel> CigaraWithTaste(int id);

    }
}
