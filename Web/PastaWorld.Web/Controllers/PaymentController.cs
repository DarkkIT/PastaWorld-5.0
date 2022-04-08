namespace PastaWorld.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
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

            if (cartIsNotEmpty && cartContentAsByteArray.Count() > 2)
            {
                cart = this.cartService.DeserializeCartContent(cartContentAsByteArray);
            }
            else
            {
                // It should be changed
                return this.Redirect("/Home/Error");
            }

            var order = new OrderPaymentViewModel
            {
                Items = cart,
            };

            foreach (var item in cart)
            {
                order.CurrentPrice += item.Meal.Price * item.Quantity;
            }

            order.MealsPrice = order.DeliveryPrice + order.CurrentPrice;

            return this.View(order);
        }

        [HttpPost]
        public IActionResult Index(OrderPaymentViewModel model)
        {
            // Change const with Enum
            if (model.UserOrOtherAddress.Equals(OrderConstants.DeliveryToOurRestaurant))
            {
                model.Address = "N/A";
                model.AddressComment = "N/A";
            }

            var cartIsNotEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

            var cart = new List<CartItemViewModel>();

            if (cartIsNotEmpty && cartContentAsByteArray.Count() > 2)
            {
                cart = this.cartService.DeserializeCartContent(cartContentAsByteArray);
            }
            else
            {
                // It should be changed
                return this.Redirect("/Home/Error");
            }

            model.Items = cart;

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
