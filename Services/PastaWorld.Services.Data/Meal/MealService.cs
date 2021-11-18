namespace PastaWorld.Services.Data.Meal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.Admins;
    using PastaWorld.Web.ViewModels.Meals;

    public class MealService : IMealService
    {
        private readonly IDeletableEntityRepository<Meal> mealRepository;

        public MealService(IDeletableEntityRepository<Meal> mealRepository)
        {
            this.mealRepository = mealRepository;
        }

        public IEnumerable<MealViewModel> GetAllSearchedMeals<T>(int page, int itemsPerPage, string searchString)
        {
            var model = this.mealRepository.All().Where(x => x.Name.Contains(searchString) && x.Type == "Основно").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public IEnumerable<MealViewModel> GetAllSearchedDrinks<T>(int page, int itemsPerPage, string searchString)
        {
            var model = this.mealRepository.All().Where(x => x.Name.Contains(searchString) && x.Type == "Напитка").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public IEnumerable<MealViewModel> GetAllSearchedDesserts<T>(int page, int itemsPerPage, string searchString)
        {
            var model = this.mealRepository.All().Where(x => x.Name.Contains(searchString) && x.Type == "Десерт").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public IEnumerable<MealViewModel> GetAllSearchedKids<T>(int page, int itemsPerPage, string searchString)
        {
            var model = this.mealRepository.All().Where(x => x.Name.Contains(searchString) && x.Type == "Детско").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public async Task AddMealAsync(AddMealInputModel input)
        {
            var meal = new Meal
            {
                Name = input.Name,
                Description = input.Description,
                ImageName = input.ImageName,
                Price = input.Price,
                Type = input.Type,
            };

            await this.mealRepository.AddAsync(meal);
            await this.mealRepository.SaveChangesAsync();
        }

        public async Task DeleteMeal(int id)
        {
            var meal = this.mealRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == id);

            this.mealRepository.Delete(meal);
            await this.mealRepository.SaveChangesAsync();
        }

        public async Task UnDeleteMeal(int id)
        {
            var news = this.mealRepository.AllWithDeleted().FirstOrDefault(x => x.Id == id);

            news.IsDeleted = false;
            news.DeletedOn = null;
            await this.mealRepository.SaveChangesAsync();
        }

        public async Task EditMealAsync(EditMealInputModel input, int id)
        {
            var news = this.mealRepository.All().FirstOrDefault(x => x.Id == id);

            news.Name = input.Name;
            news.Description = input.Description;
            news.Price = input.Price;

            await this.mealRepository.SaveChangesAsync();
        }

        public IEnumerable<MealViewModel> GetAllMeals<T>(int page, int itemsPerPage)
        {
            var model = this.mealRepository.All().Where(x => x.Type == "Основно").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public IEnumerable<MealViewModel> GetAllDrinks<T>(int page, int itemsPerPage)
        {
            var model = this.mealRepository.All().Where(x => x.Type == "Напитка").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public IEnumerable<MealViewModel> GetAllDesserts<T>(int page, int itemsPerPage)
        {
            var model = this.mealRepository.All().Where(x => x.Type == "Десерт").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public IEnumerable<MealViewModel> GetAllKids<T>(int page, int itemsPerPage)
        {
            var model = this.mealRepository.All().Where(x => x.Type == "Детско").OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public IEnumerable<MealViewModel> GetAllMealWithDeleted<T>(int page, int itemsPerPage)
        {
            var model = this.mealRepository.AllWithDeleted().OrderByDescending(x => x.Id).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<MealViewModel>().ToList();

            return model;
        }

        public MealViewModel GetById<T>(int id)
        {
            var model = this.mealRepository.All().To<MealViewModel>().FirstOrDefault(x => x.Id == id);

            return model;
        }

        public int GetCount()
        {
            return this.mealRepository.All().Count();
        }

        public IEnumerable<MealViewModel> GetLastThreeMeal<T>()
        {
            var model = this.mealRepository.All().OrderByDescending(x => x.CreatedOn).Take(3).To<MealViewModel>().ToList();

            return model;
        }
    }
}
