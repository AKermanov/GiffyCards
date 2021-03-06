﻿namespace GiffyCards.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Brands;
    using GiffyCards.Web.ViewModels.Cigar;
    using GiffyCards.Web.ViewModels.Home;

    public class CigarService : ICigarService
    {
        private readonly IDeletableEntityRepository<Cigar> cigarRepository;

        public CigarService(IDeletableEntityRepository<Cigar> cigarRepository)
        {
            this.cigarRepository = cigarRepository;
        }

        public IEnumerable<CigarWithBrandViewModel> CiagrWithSpesificShape(int shapeId)
        {
            return this.cigarRepository.AllAsNoTracking().Where(s => s.ShapeId == shapeId)
                .Select(x => new CigarWithBrandViewModel
                {
                    CiagrName = x.CigarName,
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    PriceForSingle = $"Single - US$ {x.PricePerUnit:f2}",
                    PriceForBox = $"Box 25 - US$ {x.PricePerUnit * 23:f2}",
                }).ToList();
        }

        public IEnumerable<CigarWithBrandViewModel> CigaraWithTaste(int id)
        {
            return this.cigarRepository.AllAsNoTracking().Where(x => x.TasteId == id)
                 .Select(x => new CigarWithBrandViewModel
                 {
                     Id = x.Id,
                     CiagrName = x.CigarName.Replace('-', ' '),
                     ImageUrl = x.ImageUrl,
                     PriceForSingle = $"Single - US$ {x.PricePerUnit:f2}",
                     PriceForBox = $"Box 25 - US$ {x.PricePerUnit * 23:f2}",
                 }).ToList();
        }

        public IEnumerable<CigarWithBrandViewModel> CigaraWithStrenght(int id)
        {
            return this.cigarRepository.AllAsNoTracking().Where(x => x.StrenghtId == id)
                 .Select(x => new CigarWithBrandViewModel
                 {
                     Id = x.Id,
                     CiagrName = x.CigarName.Replace('-', ' '),
                     ImageUrl = x.ImageUrl,
                     PriceForSingle = $"Single - US$ {x.PricePerUnit:f2}",
                     PriceForBox = $"Box 25 - US$ {x.PricePerUnit * 23:f2}",
                 }).ToList();
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
                     }).ToList(),
                 }).FirstOrDefault();
        }

        public IEnumerable<CigarsHeroItemViewModel> GetWeaklySpecial()
        {
            return this.cigarRepository.AllAsNoTracking()
                .OrderBy(r => Guid.NewGuid())
                .Take(5)
                .Select(x => new CigarsHeroItemViewModel
                {
                    Id = x.Id,
                    CigarName = x.CigarName,
                    Discount = Math.Round((x.PricePerUnit / 5) + 10).ToString("G29") + '%',
                    ImageUrl = x.ImageUrl,
                }).ToList();
        }

        public IEnumerable<CigarWithBrandViewModel> AllCigars(int page, int itemsPerPage = 8)
        {
            return this.cigarRepository.AllAsNoTracking()
                .OrderBy(x => x.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .Select(x => new CigarWithBrandViewModel
            {
                Id = x.Id,
                CiagrName = x.CigarName.Replace('-', ' '),
                ImageUrl = x.ImageUrl,
                PriceForSingle = $"Single - US$ {x.PricePerUnit:f2}",
                PriceForBox = $"Box 25 - US$ {x.PricePerUnit * 23:f2}",
            }).ToList();
        }

        public int GetCount()
        {
            return this.cigarRepository.All().Count();
        }
    }
}
