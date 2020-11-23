namespace GiffyCards.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GiffyCards.Data.Common.Models;
    using GiffyCards.Data.Common.Repositories;
    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;

    public class StoreService //: IStoreService
    {
        /*
        private readonly IDeletableEntityRepository<Store> storeRepository;

        public StoreService(IDeletableEntityRepository<Store> storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        public IEnumerable<T> GetAllStores<T>(int? count = null)
        {
            var stores = this.storeRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                stores = (IOrderedQueryable<Store>)stores.Take(count.Value);
            }

            return stores.To<T>().ToList();
        }
        */
    }
}
