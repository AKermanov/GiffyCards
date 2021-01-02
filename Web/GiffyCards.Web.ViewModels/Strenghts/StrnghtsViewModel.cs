namespace GiffyCards.Web.ViewModels.Strenghts
{
    using GiffyCards.Data.Models;
    using GiffyCards.Services.Mapping;

    public class StrnghtsViewModel : IMapFrom<Strenght>
    {
        public int Id { get; set; }

        public string StrenghtType { get; set; }

        public string PictureUrl { get; set; }
    }
}
