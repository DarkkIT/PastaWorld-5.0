namespace PastaWorld.Web.ViewModels.News
{
    using System.Collections.Generic;

    public class NewsListViewModel : PagingViewModel
    {
        public IEnumerable<NewsViewModel> NewsList { get; set; }
    }
}
