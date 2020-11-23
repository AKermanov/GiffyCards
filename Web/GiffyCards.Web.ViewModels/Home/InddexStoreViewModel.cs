
namespace GiffyCards.Web.ViewModels.Home
{
   public class InddexStoreViewModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Url => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
