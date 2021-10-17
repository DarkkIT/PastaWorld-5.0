namespace PastaWorld.Web.Controllers
{
    using System.Diagnostics;

    using PastaWorld.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using PastaWorld.Services.Data.News;
    using PastaWorld.Web.ViewModels.News;
    using PastaWorld.Common;

    public class HomeController : BaseController
    {
        private readonly INewsService newsService;

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public IActionResult Index()
        {
            var newses = this.newsService.GetLastThreeNews<NewsViewModel>();
            var viewModel = new NewsListViewModel { NewsList = newses};

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
