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

    public class MenuController : BaseController
    {
        private readonly IMealService mealService;

        public MenuController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        public IActionResult Index(string searchType, string searchString, int id = 1)
        {

            this.ViewData["CurrentFilter"] = searchString;
            this.ViewData["TypeFilter"] = searchType;

            IEnumerable<MealViewModel> meals = null;


            if (!String.IsNullOrEmpty(searchString))
            {
                meals = this.mealService.GetAllSearchedBikes<MealViewModel>(id, 6, searchString);
            }
            else
            {
                meals = this.mealService.GetAllMeal<MealViewModel>(id, 6);
            }

            //var meals = this.mealService.GetAllMeal<MealViewModel>(id, 1);
            //var viewModel = new MealListViewModel { MealList = meals };

            var viewModel = new MealListViewModel { MealList = meals, PageNumber = id, MotorBikeCount = this.mealService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

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
