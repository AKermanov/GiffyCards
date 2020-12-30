using GiffyCards.Data.Common.Repositories;
using GiffyCards.Data.Models;
using GiffyCards.Web.ViewModels.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiffyCards.Services.Data
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IDeletableEntityRepository<Cigar> cigarEntity;
        private readonly IDeletableEntityRepository<ShoppingCart> shoppingCartEntity;

        public ShoppingCartService(
            IDeletableEntityRepository<Cigar> cigarEntity,
            IDeletableEntityRepository<ShoppingCart> shoppingCartEntity)
        {
            this.cigarEntity = cigarEntity;
            this.shoppingCartEntity = shoppingCartEntity;
        }

        public async Task AddProduct(int productId, string userId, int quantityForSingle)
        {
            var cigar = this.cigarEntity.AllAsNoTracking().Where(y => y.Id == productId).Select(x => new ShoppingCart
            {
                UserId = userId,
                QuantityForSingle = quantityForSingle,
                PriceForSingle = x.PricePerUnit,
                CigarId = x.Id,
            }).FirstOrDefault();

            await this.shoppingCartEntity.AddAsync(cigar);
            await this.shoppingCartEntity.SaveChangesAsync();
        }

        public IEnumerable<ShoppingViewModel> GetAllByUser(string userId)
        {
            return this.shoppingCartEntity.AllAsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(y => new ShoppingViewModel
                {
                    CigarId = y.CigarId ?? 0,
                    CigarShape = y.Cigar.Shape.ShapeName,
                    ImageUrl = y.Cigar.ImageUrl,
                    PriceForSingle = y.Cigar.PricePerUnit,
                    CigarName = y.Cigar.CigarName,
                    Quantity = y.QuantityForSingle,
                    TotalPrice = (y.Cigar.PricePerUnit * y.QuantityForSingle) ?? 0,
                }).ToList();
        }

        public decimal OrdarTotal(IEnumerable<ShoppingViewModel> input)
        {
            return input.Sum(x => x.TotalPrice);
        }

        public async Task RemoveFromCart(int id, string userId)
        {
            var current = this.shoppingCartEntity.AllAsNoTracking().FirstOrDefault(x => x.CigarId == id && x.UserId == userId);

            this.shoppingCartEntity.Delete(current);

            await this.shoppingCartEntity.SaveChangesAsync();
        }
    }
}
