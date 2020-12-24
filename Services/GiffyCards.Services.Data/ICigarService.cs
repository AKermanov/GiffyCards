namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;
    using GiffyCards.Web.ViewModels.Home;

    public interface ICigarService
    {
        IEnumerable<CigarsHeroItemViewModel> GetWeaklySpecial();

        IEnumerable<CigarWithBrandViewModel> AllCigars(int page, int itemsPerPage = 8);

        IEnumerable<CigarWithBrandViewModel> CigaraWithTaste(int id);

        IEnumerable<CigarWithBrandViewModel> CiagrWithSpesificShape(int brandId);

        public IEnumerable<CigarWithBrandViewModel> CigaraWithStrenght(int id);

        SingleCigarViewModel GetSingleCigarById(int id);

        int GetCount();
    }
}
