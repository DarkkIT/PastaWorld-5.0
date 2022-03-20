namespace PastaWorld.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Providers.Entities;

    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using PastaWorld.Data.Models;
    using PastaWorld.Services.Data.Meal;
    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Meals;

    public class CartController : BaseController
    {
        private readonly IMealService mealService;

        public CartController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        public IActionResult Index()
        {
            var cartIsNotEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

            List<CartItemViewModel> cart;

            if (cartIsNotEmpty)
            {
                var reader = new StreamReader(new MemoryStream(cartContentAsByteArray), Encoding.Default);

                cart = new Newtonsoft.Json
                    .JsonSerializer()
                    .Deserialize<List<CartItemViewModel>>(new JsonTextReader(reader));
            }
            else
            {
                cart = new List<CartItemViewModel>();
                var serializedCart = JsonConvert.SerializeObject(cart);
                var cartAsByteArray = Encoding.UTF8.GetBytes(serializedCart);
                this.HttpContext.Session.Set("cart", cartAsByteArray);
            }

            /*SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");*/
            //this.ViewBag.cart = cart;
            //this.ViewBag.total = cart.Sum(item => item.Meal.Price * item.Quantity);

            return this.View(cart);
        }

        public IActionResult Remove(int id)
        {
            var cartExists = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

            var cart = new List<CartItemViewModel>();

            StreamReader streamReader;
            GetCartContent(out cart, cartContentAsByteArray, out streamReader);

            if (cart.Any(x => x.Meal.Id == id))
            {
                var cartItem = cart.FirstOrDefault(x => x.Meal.Id == id);
                if (cartItem.Quantity == 1)
                {
                    cart.Remove(cartItem);
                }
                else if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
            }

            var serializedCart = JsonConvert.SerializeObject(cart);
            var cartAsByteArray = Encoding.UTF8.GetBytes(serializedCart);
            this.HttpContext.Session.Set("cart", cartAsByteArray);

            return this.RedirectToAction("Index");
        }

        public IActionResult Add(int id)
        {
            var meal = this.mealService.GetById<MealAsCartItemViewModel>(id);

            //TODO: Add Cart service

            List<CartItemViewModel> cart;

            var cartExists = this.HttpContext.Session.TryGetValue("cart", out byte[] result);

            if (!cartExists)
            {
                this.InitializeCart(out cart, out cartExists, out result);
            }

            StreamReader reader;
            GetCartContent(out cart, result, out reader);

            if (cart.Any(x => x.Meal.Id == meal.Id))
            {
                cart.FirstOrDefault(x => x.Meal.Id == meal.Id).Quantity++;
            }
            else
            {
                var cartItem = new CartItemViewModel
                {
                    Meal = meal,
                    Quantity = 1,
                };
                cart.Add(cartItem);
            }

            var serializedCart = JsonConvert.SerializeObject(cart);
            var cartAsByteArray = Encoding.UTF8.GetBytes(serializedCart);
            this.HttpContext.Session.Set("cart", cartAsByteArray);

            return this.RedirectToAction("Index");
        }

        private static void GetCartContent(out List<CartItemViewModel> cart, byte[] result, out StreamReader reader)
        {
            reader = new StreamReader(new MemoryStream(result), Encoding.Default, true, 10000);
            cart = new Newtonsoft.Json
                .JsonSerializer()
                .Deserialize<List<CartItemViewModel>>(new JsonTextReader(reader));
        }

        private void InitializeCart(out List<CartItemViewModel> cart, out bool cartExists, out byte[] result)
        {
            cart = new List<CartItemViewModel>();
            var serializedCart1 = JsonConvert.SerializeObject(cart);
            var cartAsByteArray1 = System.Text.Encoding.UTF8.GetBytes(serializedCart1);
            this.HttpContext.Session.Set("cart", cartAsByteArray1);
            this.ViewBag.cart = cart;
            cartExists = this.HttpContext.Session.TryGetValue("cart", out result);
        }
    }
}
