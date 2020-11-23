namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    public interface IStoreService
    {
        IEnumerable<T> GetAllStores<T>(int? count = null);
    }
}
