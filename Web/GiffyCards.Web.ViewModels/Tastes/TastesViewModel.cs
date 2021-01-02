namespace GiffyCards.Web.ViewModels.Tastes
{
    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;

    public class TastesViewModel : IMapFrom<Taste>
    {
        public int Id { get; set; }

        public string TasteType { get; set; }

        public string ImageUrl { get; set; }
    }
}
