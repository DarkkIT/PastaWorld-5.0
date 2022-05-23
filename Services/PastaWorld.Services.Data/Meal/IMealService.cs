namespace PastaWorld.Services.Data.Meal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using PastaWorld.Web.ViewModels.Admins;
    using PastaWorld.Web.ViewModels.Meals;

    public interface IMealService
    {
        Task AddMealAsync(AddMealInputModel input);

        Task EditMealAsync(EditMealInputModel input, int id);

        IEnumerable<MealViewModel> GetAllMeals<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllPasta<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllPizza<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllSalads<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllDrinks<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllDesserts<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllKids<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllMealWithDeleted<T>(int page, int itemsPerPage, string adminPageName);

        IEnumerable<MealViewModel> GetAllSearchedMeals<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedPasta<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedPizza<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedSalads<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedDrinks<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedDesserts<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedKids<T>(int page, int itemsPerPage, string searchString);

        int GetCount();

        IEnumerable<MealViewModel> GetLastThreeMeal<T>();

        T GetById<T>(int id);

        MealViewModel GetById(int id);

        Task DeleteMeal(int id);

        Task UnDeleteMeal(int id);

        Task MakeTop(int id);
    }
}
