namespace PastaWorld.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using PastaWorld.Common;
    using PastaWorld.Services.Data.Meal;
    using PastaWorld.Web.ViewModels;
    using PastaWorld.Web.ViewModels.Meals;

    public class MealController : BaseController
    {
        private readonly IMealService mealService;

        public MealController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        public IActionResult Index(string typeName, string searchType, string searchString, int id = 1)
        {
            this.ViewData["CurrentFilter"] = searchString;
            this.ViewData["TypeFilter"] = searchType;

            IEnumerable<MealViewModel> meals = null;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (typeName == "meal")
                {
                    meals = this.mealService.GetAllSearchedMeals<MealViewModel>(id, 100, searchString);
                }
                else if (typeName == "drink")
                {
                    meals = this.mealService.GetAllSearchedDrinks<MealViewModel>(id, 100, searchString);
                }
                else if (typeName == "dessert")
                {
                    meals = this.mealService.GetAllSearchedDesserts<MealViewModel>(id, 100, searchString);
                }
                else if (typeName == "kids")
                {
                    meals = this.mealService.GetAllSearchedKids<MealViewModel>(id, 100, searchString);
                }
            }
            else
            {
                if (typeName == "meal")
                {
                    meals = this.mealService.GetAllMeals<MealViewModel>(id, 100);
                }
                else if (typeName == "drink")
                {
                    meals = this.mealService.GetAllDrinks<MealViewModel>(id, 100);
                }
                else if (typeName == "dessert")
                {
                    meals = this.mealService.GetAllDesserts<MealViewModel>(id, 100);
                }
                else if (typeName == "kids")
                {
                    meals = this.mealService.GetAllKids<MealViewModel>(id, 100);
                }
            }

            var viewModel = new MealListViewModel { MealList = meals, PageNumber = id, MotorBikeCount = this.mealService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage, TypeName = typeName };

            if (typeName == "meal")
            {
                viewModel.PageName = "Направено с Любов за Вас";
            }
            else if (typeName == "drink")
            {
                viewModel.PageName = "За по пълноценна вечеря";
            }
            else if (typeName == "dessert")
            {
                viewModel.PageName = "Наслада за завършек";
            }
            else if (typeName == "kids")
            {
                viewModel.PageName = "За най-малките с любов";
            }

            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
