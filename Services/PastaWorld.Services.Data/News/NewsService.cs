namespace PastaWorld.Services.Data.News
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.Admins;
    using PastaWorld.Web.ViewModels.News;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;

        public NewsService(IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task AddNewsAsync(AddNewsInputModel input)
        {
            var news = new News
            {
                Name = input.Name,
                Description = input.Description,
                ImageName = input.ImageName,
                NewsDate = DateTime.UtcNow,
            };

            await this.newsRepository.AddAsync(news);
            await this.newsRepository.SaveChangesAsync();
        }

        public async Task DeleteNews(int id)
        {
            var news = this.newsRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);

            this.newsRepository.Delete(news);
            await this.newsRepository.SaveChangesAsync();
        }

        public async Task UnDeleteNews(int id)
        {
            var news = this.newsRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);

            news.IsDeleted = false;
            news.DeletedOn = null;
            await this.newsRepository.SaveChangesAsync();
        }

        public async Task EditNewsAsync(EditNewsInputModel input, int id)
        {
            var news = this.newsRepository.All().FirstOrDefault(x => x.Id == id);

            news.Name = input.Name;
            news.Description = input.Description;
            news.NewsDate = input.NewsDate;

            await this.newsRepository.SaveChangesAsync();
        }

        public IEnumerable<NewsViewModel> GetAllNews<T>(int page, int itemsPerPage)
        {
            var model = this.newsRepository.All().OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<NewsViewModel>().ToList();

            return model;
        }

        public IEnumerable<NewsViewModel> GetAllNewsWithDeleted<T>(int page, int itemsPerPage)
        {
            var model = this.newsRepository.AllWithDeleted().OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<NewsViewModel>().ToList();

            return model;
        }

        public NewsViewModel GetById<T>(int id)
        {
            var model = this.newsRepository.All().To<NewsViewModel>().FirstOrDefault(x => x.Id == id);

            return model;
        }

        public int GetCount()
        {
            return this.newsRepository.All().Count();
        }

        public IEnumerable<NewsViewModel> GetLastThreeNews<T>()
        {
            var model = this.newsRepository.All().OrderByDescending(x => x.CreatedOn).Take(3).To<NewsViewModel>().ToList();

            return model;
        }
    }
}
