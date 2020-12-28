namespace GiffyCards.Web.Areas.Administration.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;

    public interface ICigarServiceAdmin
    {
        Task CreateCigar(CreateCigarInputModel input);

        Task DeleteCigarConfirmed(int id);

        Task<Cigar> CigarDetails(int? id);

        Task<Cigar> DeleteCigar(int? id);

        IEnumerable<SingleCigarViewModel> GetAll();

        IEnumerable<KeyValuePair<string, string>> BrandsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> ShapeAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> SizeAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> TasteAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> StrengthAsKeyValuePairs();
    }
}
