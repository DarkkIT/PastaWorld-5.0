namespace PastaWorld.Web.ViewModels
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int MotorBikeCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool HasPreviosPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PreviosPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.MotorBikeCount / this.ItemsPerPage);
    }
}
