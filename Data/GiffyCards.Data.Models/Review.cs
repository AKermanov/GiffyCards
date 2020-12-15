namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public Review()
        {
            this.Accessories = new HashSet<Accessorie>();
        }

        public int Score { get; set; }

        public string ReviewText { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int CigarId { get; set; }

        public Cigar Cigar { get; set; }

        public virtual ICollection<Accessorie> Accessories { get; set; }
    }
}
