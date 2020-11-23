
namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Description : BaseDeletableModel<int>
    {
        public Description()
        {
            this.Accessories = new HashSet<Accessorie>();
            this.Cigars = new HashSet<Cigar>();
        }

        public string DescriptionText { get; set; }

        public virtual ICollection<Accessorie> Accessories { get; set; }

        public virtual ICollection<Cigar> Cigars { get; set; }
    }
}
