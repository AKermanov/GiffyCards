namespace GiffyCards.Web.ViewModels.Cigar
{
    using System;
    using System.Collections.Generic;

    using GiffyCards.Data.Models;
    using GiffyCards.Web.ViewModels.Reviews;

    public class SingleCigarViewModel
    {
        public int Id { get; set; }

        public virtual Brand Brand { get; set; }

        public string CigarName { get; set; }

        public virtual Strenght Strenght { get; set; }

        public virtual Taste Taste { get; set; }

        public virtual Size Size { get; set; }

        public Question Question { get; set; }

        public string Bland { get; set; }

        public Description Description { get; set; }

        public Shape Shape { get; set; }

        public string PriceForSingle { get; set; }

        public string PriceForBox { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? CreatedOn { get; set; }

        public IEnumerable<ReviewsViewModel> Reviews { get; set; }
    }
}
