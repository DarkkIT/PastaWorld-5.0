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

    public class CartController : Controller
    {
        private readonly IMealService mealService;

        public CartController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        public IActionResult Index()
        {
            var isCartEmpty =
                this.HttpContext
                .Session
                .TryGetValue("cart", out byte[] result);
            List<CartItem> cart;

            if (isCartEmpty)
            {
                var reader = new StreamReader(new MemoryStream(result), Encoding.Default);

                cart = new Newtonsoft.Json
                    .JsonSerializer()
                    .Deserialize<List<CartItem>>(new JsonTextReader(reader));
            }
            else
            {
                cart = new List<CartItem>();
                var serializedCart = JsonConvert.SerializeObject(cart);
                var cartAsByteArray = System.Text.Encoding.UTF8.GetBytes(serializedCart);
                this.HttpContext.Session.Set("cart", cartAsByteArray);
            }

            /*SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");*/
            this.ViewBag.cart = cart;
            this.ViewBag.total = cart.Sum(item => item.Meal.Price * item.Quantity);

            return this.View(cart);
        }

        public IActionResult Add(int id)
        {
            var meal = this.mealService.GetById(id);

            var cartItem = new CartItem
            {
                Meal = new Meal
                {
                    Id = meal.Id,
                    Price = meal.Price,
                    Name = meal.Name,
                },
                Quantity = 1,
            };

            var isCartEmpty =
               this.HttpContext
               .Session
               .TryGetValue("cart", out byte[] result);

            List<CartItem> cart;
            if (!isCartEmpty)
            {
                cart = new List<CartItem>();
                var serializedCart = JsonConvert.SerializeObject(cart);
                var cartAsByteArray = System.Text.Encoding.UTF8.GetBytes(serializedCart);
                this.HttpContext.Session.Set("cart", cartAsByteArray);
                isCartEmpty = true;
            }

            if (isCartEmpty)
            {
                var reader = new StreamReader(new MemoryStream(result), Encoding.Default);

                cart = new Newtonsoft.Json
                    .JsonSerializer()
                    .Deserialize<List<CartItem>>(new JsonTextReader(reader));

                if (cart.Any(x => x.Meal.Id == cartItem.Meal.Id))
                {
                    cart.FirstOrDefault(x => x.Meal.Id == cartItem.Meal.Id).Quantity++;
                }
                else
                {
                 cart.Add(cartItem);
                }

                var serializedCart = JsonConvert.SerializeObject(cart);
                var cartAsByteArray = System.Text.Encoding.UTF8.GetBytes(serializedCart);
                this.HttpContext.Session.Set("cart", cartAsByteArray);
            }

            return this.RedirectToAction("Index");
        }
    }
}
