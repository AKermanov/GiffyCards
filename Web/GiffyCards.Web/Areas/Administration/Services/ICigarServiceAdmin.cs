namespace GiffyCards.Web.Areas.Administration.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;

    public interface ICigarServiceAdmin
    {
        Task CreateCigar (CreateCigarInputModel input);

        Task<IEnumerable<CigarWithBrandViewModel>> GetAll(SingleCigarViewModel cigars);
    }
}
