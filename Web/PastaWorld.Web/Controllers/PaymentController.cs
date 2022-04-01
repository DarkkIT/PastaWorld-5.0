
using System.Data;

namespace PastaWorld.Web.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    using PastaWorld.Services.Data.Cart;
    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Orders;

    public class PaymentController : BaseController
    {
        private readonly ICartService cartService;

        public PaymentController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
            var cartIsNotEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

            var cart = new List<CartItemViewModel>();

            if (cartIsNotEmpty)
            {
                cart = this.cartService.DeserializeCartContent(cartContentAsByteArray);
            }
            else
            {
                byte[] cartAsByteArray = this.cartService.SerializeCartContent(cart);
                this.HttpContext.Session.Set("cart", cartAsByteArray);
            }

            var order = new OrderPaymentViewModel
            {
                Items = cart,
            };

            foreach (var item in cart)
            {
                order.CurrentPrice += item.Meal.Price * item.Quantity;
            }

            order.DeliveryPrice = 5.0m;
            order.MealsPrice = order.DeliveryPrice + order.CurrentPrice;

            return this.View(order);
        }

        [HttpPost]
        public IActionResult Index(OrderPaymentViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var cartIsNotEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

                var cart = new List<CartItemViewModel>();

                if (cartIsNotEmpty)
                {
                    cart = this.cartService.DeserializeCartContent(cartContentAsByteArray);
                }
                else
                {
                    byte[] cartAsByteArray = this.cartService.SerializeCartContent(cart);
                    this.HttpContext.Session.Set("cart", cartAsByteArray);
                }

                var order = new OrderPaymentViewModel
                {
                    Items = cart,
                };

                return this.View(order);
            }

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
