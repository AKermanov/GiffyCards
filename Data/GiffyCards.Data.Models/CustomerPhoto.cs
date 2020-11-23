namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class CustomerPhoto : BaseDeletableModel<int>
    {
        public CustomerPhoto()
        {
            this.CustomerPhotos = new HashSet<ApplicationUser>();
        }

        public string PhotoUrl { get; set; }

        public string PhotoText { get; set; }

        public virtual ICollection<ApplicationUser> CustomerPhotos { get; set; }
    }
}
