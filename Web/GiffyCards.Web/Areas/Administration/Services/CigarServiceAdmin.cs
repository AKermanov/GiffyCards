namespace GiffyCards.Web.Areas.Administration.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;

    public class CigarServiceAdmin : ICigarServiceAdmin
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepository;

        public CigarServiceAdmin(IDeletableEntityRepository<Cigar> cigarRepository)
        {
            this.cigarRepository = cigarRepository;
        }

        public async Task CreateCigar(CreateCigarInputModel input)
        {
            var cigar = new Cigar
            {
               // use auto mapper!!!
            };

            await this.cigarRepository.AddAsync(cigar);
            await this.cigarRepository.SaveChangesAsync();
        }

        public Task<IEnumerable<CigarWithBrandViewModel>> GetAll(SingleCigarViewModel cigars)
        {
            throw new System.NotImplementedException();
        }
    }
}
