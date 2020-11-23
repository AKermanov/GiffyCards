namespace GiffyCards.Data.Models
{
    using System.Collections.Generic;

    using GiffyCards.Data.Common.Models;

    public class Question : BaseDeletableModel<int>
    {
        public Question()
        {
            this.Accessories = new HashSet<Accessorie>();
            this.Cigars = new HashSet<Cigar>();
        }

        public string QuestionText { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Accessorie> Accessories { get; set; }

        public virtual ICollection<Cigar> Cigars { get; set; }
    }
}
