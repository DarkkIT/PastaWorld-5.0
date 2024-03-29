﻿namespace PastaWorld.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using PastaWorld.Common;
    using PastaWorld.Services.Data.Meal;
    using PastaWorld.Services.Data.News;
    using PastaWorld.Web.ViewModels.Admins;
    using PastaWorld.Web.ViewModels.Meals;
    using PastaWorld.Web.ViewModels.News;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly INewsService newsService;
        private readonly IMealService mealService;

        public AdminController(IWebHostEnvironment webHostEnvironment, INewsService newsService, IMealService mealService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.newsService = newsService;
            this.mealService = mealService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AddNews()
        {
            return this.View();
        }

        public IActionResult AddMeal()
        {
            return this.View();
        }

        public async Task<IActionResult> MakeTop(int id, string name)
        {
            await this.mealService.MakeTop(id);

            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, name);
            var viewModel = new MealListViewModel { TypeName = name, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult Success()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(AddNewsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (input.Image != null && input.Image.Length > 0)
            {
                using (FileStream fs = new FileStream(this.webHostEnvironment.WebRootPath + ("/images/news/" + input.ImageName + ".jpg"), FileMode.Create))
                {
                    await input.Image.CopyToAsync(fs);
                }
            }

            await this.newsService.AddNewsAsync(input);

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal(AddMealInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (input.Image != null && input.Image.Length > 0)
            {
                using (FileStream fs = new FileStream(this.webHostEnvironment.WebRootPath + ("/images/meals/" + input.ImageName + ".jpg"), FileMode.Create))
                {
                    await input.Image.CopyToAsync(fs);
                }
            }

            await this.mealService.AddMealAsync(input);

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult AllNews()
        {
            var newses = this.newsService.GetAllNewsWithDeleted<NewsViewModel>(1, 1000);
            var viewModel = new NewsListViewModel { NewsList = newses, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult AllMeals(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult GetMain(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult GetPasta(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult GetPizza(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult GetSalads(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult GetDrinks(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult GetDesserts(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }

        public IActionResult GetKids(string adminPageName)
        {
            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, adminPageName);
            var viewModel = new MealListViewModel { TypeName = adminPageName, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.View(viewModel);
        }


        public IActionResult EditNews(int id)
        {
            var viewModel = this.newsService.GetById<NewsViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult EditMeal(int id)
        {
            var viewModel = this.mealService.GetById<MealViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditNews(EditNewsInputModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.newsService.EditNewsAsync(input, id);

            return this.RedirectToAction(nameof(this.Success));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> EditMeal(EditMealInputModel input, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.mealService.EditMealAsync(input, id);

            return this.RedirectToAction(nameof(this.Success));
        }

        public async Task<IActionResult> DeleteNews(int id)
        {
            await this.newsService.DeleteNews(id);

            return this.RedirectToAction(nameof(this.AllNews));
        }

        public async Task<IActionResult> DeleteMeal(int id, string name)
        {
            await this.mealService.DeleteMeal(id);

            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, name);
            var viewModel = new MealListViewModel { TypeName = name, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };

            return this.RedirectToAction(nameof(this.AllMeals), new { adminPageName = name });
        }

        public async Task<IActionResult> UnDeleteNews(int id)
        {
            await this.newsService.UnDeleteNews(id);

            return this.RedirectToAction(nameof(this.AllNews));
        }

        public async Task<IActionResult> UnDeleteMeal(int id, string name)
        {
            await this.mealService.UnDeleteMeal(id);

            var meals = this.mealService.GetAllMealWithDeleted<MealViewModel>(1, 1000, name);
            var viewModel = new MealListViewModel { TypeName = name, MealList = meals, PageNumber = 1, MotorBikeCount = this.newsService.GetCount(), ItemsPerPage = GlobalConstants.ItemsPerPage };


            return this.RedirectToAction(nameof(this.AllMeals), new { adminPageName = name });
        }
    }
}
