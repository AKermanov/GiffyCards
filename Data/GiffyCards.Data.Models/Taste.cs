namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Taste : BaseDeletableModel<int>
    {
        public Taste()
        {
            this.Cigars = new HashSet<Cigar>();
        }

        public string TasteType { get; set; }

        public string PictureUrl { get; set; }

        public virtual ICollection<Cigar> Cigars { get; set; }
    }
}
