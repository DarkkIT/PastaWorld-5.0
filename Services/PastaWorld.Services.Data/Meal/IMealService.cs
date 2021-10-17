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

        IEnumerable<MealViewModel> GetAllMeal<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllMealWithDeleted<T>(int page, int itemsPerPage);

        IEnumerable<MealViewModel> GetAllSearchedBikes<T>(int page, int itemsPerPage, string searchString);

        int GetCount();

        IEnumerable<MealViewModel> GetLastThreeMeal<T>();

        MealViewModel GetById<T>(int id);

        Task DeleteMeal(int id);

        Task UnDeleteMeal(int id);
    }
}
