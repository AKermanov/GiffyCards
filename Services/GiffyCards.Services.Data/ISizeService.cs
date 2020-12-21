namespace GiffyCards.Services.Data
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Sizes;

    public interface ISizeService
    {
        public IEnumerable<ShapeAndSizeViewModel> GetAllShapesAndSizes();
    }
}
