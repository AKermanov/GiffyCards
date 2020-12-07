namespace GiffyCards.Data.Models
{
    using System;
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class CustomerPhoto : BaseDeletableModel<string>
    {
        public CustomerPhoto()
        {
            this.CustomerPhotos = new HashSet<ApplicationUser>();
            this.Id = Guid.NewGuid().ToString();
        }

        public int? CigarId { get; set; }

        public Cigar Cigar { get; set; }

        public string Extension { get; set; }

        public string PhotoText { get; set; }

        public virtual ICollection<ApplicationUser> CustomerPhotos { get; set; }

        // The content of the image is in the file sysem
    }
}
