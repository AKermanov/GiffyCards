namespace GiffyCards.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Cigar;
    using GiffyCards.Web.ViewModels.Home;

    public class CigarService : ICigarService
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepository;
        private readonly IRepository<Review> reviewRepository;

        public CigarService(IDeletableEntityRepository<Cigar> cigarRepository, IRepository<Review> reviewRepository)
        {
            this.cigarRepository = cigarRepository;
            this.reviewRepository = reviewRepository;
        }

        public SingleCigarViewModel GetSingleCigarById(int id)
        {
            return this.cigarRepository.AllAsNoTracking().Where(x => x.Id == id)
                 .Select(x => new SingleCigarViewModel
                 {
                     Id = x.Id,
                     Shape = x.Shape,
                     Size = x.Size,
                     Bland = x.Bland,
                     Strenght = x.Strenght,
                     Brand = x.Brand,
                     CigarName = x.CigarName,
                     ImageUrl = x.ImageUrl,
                     Description = x.Description,
                     PriceForSingle = $"Single - ${x.PricePerUnit:f2}",
                     PriceForBox = $"Box 25 - ${x.PricePerUnit * 23:f2}",
                     Question = x.Question,
                     Taste = x.Taste,
                     Reviews = x.Reviews
                     .Where(r => r.CigarId == id)
                     .Select(v => new ReviewsViewModel
                     {
                         Score = v.Score,
                         Name = v.Name,
                         ReviewText = v.ReviewText,
                         CigarId = v.CigarId,
                     }).ToList()
,
                 }).FirstOrDefault();
        }

        public IEnumerable<CigarsHeroItemViewModel> GetWeaklySpecial()
        {
            return this.cigarRepository.AllAsNoTracking()
                .Take(5)
                .Select(x => new CigarsHeroItemViewModel
                {
                    Id = x.Id,
                    CigarName = x.CigarName,
                    Discount = Math.Round((x.PricePerUnit / 2) + 10).ToString("G29") + '%',
                    ImageUrl = x.ImageUrl,
                }).ToList();
        }
    }
}
