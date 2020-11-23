namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Brand : BaseDeletableModel<int>
    {
        public Brand()
        {
            this.Cigars = new HashSet<Cigar>();
        }

        public string BrandName { get; set; }

        public virtual ICollection<Cigar> Cigars { get; set; }
    }
}
