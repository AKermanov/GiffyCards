namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Shape : BaseDeletableModel<int>
    {
        public Shape()
        {
            this.Cigars = new HashSet<Cigar>();
        }

        public string ShapeName { get; set; }

        public virtual ICollection<Cigar> Cigars { get; set; }
    }
}
