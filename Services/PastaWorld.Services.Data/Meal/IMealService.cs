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

        IEnumerable<MealViewModel> GetAllDrinks<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllDesserts<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllKids<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllMealWithDeleted<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllSearchedMeals<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedDrinks<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedDesserts<T>(int page, int itemsPerPage, string searchString);

        IEnumerable<MealViewModel> GetAllSearchedKids<T>(int page, int itemsPerPage, string searchString);

        int GetCount();

        IEnumerable<MealViewModel> GetLastThreeMeal<T>();

        MealViewModel GetById<T>(int id);

        Task DeleteMeal(int id);

        Task UnDeleteMeal(int id);
    }
}
