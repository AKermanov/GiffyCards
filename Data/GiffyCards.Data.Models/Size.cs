namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Size : BaseDeletableModel<int>
    {
        public Size()
        {
            this.Cigars = new HashSet<Cigar>();
        }

        public string Shape { get; set; }

        public string Lenght { get; set; }

        public string RingRange { get; set; }

        public virtual ICollection<Cigar> Cigars { get; set; }
    }
}
