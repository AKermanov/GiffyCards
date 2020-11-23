namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Strenght : BaseDeletableModel<int>
    {
        public Strenght()
        {
            this.Cigars = new HashSet<Cigar>();
        }

        public string StrenghtType { get; set; }

        public virtual ICollection<Cigar> Cigars { get; set; }
    }
}
