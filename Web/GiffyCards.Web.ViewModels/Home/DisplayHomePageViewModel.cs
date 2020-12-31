namespace GiffyCards.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Pictures;

    public class DisplayHomePageViewModel
    {
       public IEnumerable<CigarsHeroItemViewModel> Cigars { get; set; }

       public IEnumerable<DisplayPictureViewModel> CustomerPictures { get; set; }

    }
}
