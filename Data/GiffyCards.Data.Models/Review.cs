namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Review : BaseModel<int>
    {
        public byte Score { get; set; }

        public string ReviewText { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int? CigarId { get; set; }

        public virtual Cigar Cigar { get; set; }

        public int? AccessorieId { get; set; }

        public virtual Accessorie Accessorie { get; set; }
    }
}
