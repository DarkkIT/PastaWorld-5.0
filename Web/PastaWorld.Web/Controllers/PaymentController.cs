namespace PastaWorld.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Orders;

    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            var isCartEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

            var cart = new List<CartItemViewModel>();

            if (!isCartEmpty)
            {
                this.InitializeCart(out cart, out isCartEmpty, out cartContentAsByteArray);
            }

            var reader = new StreamReader(new MemoryStream(cartContentAsByteArray), Encoding.Default);
            cart = new Newtonsoft.Json.JsonSerializer().Deserialize<List<CartItemViewModel>>(new JsonTextReader(reader));

            var order = new OrderPaymentViewModel();
            order.Items = cart;

            return this.View(order);
        }

        [HttpPost]
        public IActionResult FinalyzeOrder()
        {
            return this.View();
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
