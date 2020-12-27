namespace GiffyCards.Web.ViewModels.Cigar
{
    using System;
    using System.Collections.Generic;

    using GiffyCards.Web.ViewModels.Brands;

    public class AllCIgarsViewModel
    {
        public IEnumerable<CigarWithBrandViewModel> All { get; set; }

        public int PageNumber { get; set; }

        public int CigarsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.CigarsCount / this.ItemsPerPage);
    }
}
