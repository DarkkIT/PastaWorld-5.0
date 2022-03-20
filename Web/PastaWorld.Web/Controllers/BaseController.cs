namespace PastaWorld.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using PastaWorld.Web.ViewModels.Cart;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class BaseController : Controller
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var cart = new List<CartItemViewModel>();
        //    var cartIsNotEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);
        //    if (cartIsNotEmpty)
        //    {
        //    var reader = new StreamReader(new MemoryStream(cartContentAsByteArray), Encoding.Default);
        //    cart = new Newtonsoft.Json
        //            .JsonSerializer()
        //            .Deserialize<List<CartItemViewModel>>(new JsonTextReader(reader));

        //    }
        //    this.ViewBag.CartItems = cart.Count;
        //}

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var cart = new List<CartItemViewModel>();
            var cartIsNotEmpty = context.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);
            if (cartIsNotEmpty)
            {
                var reader = new StreamReader(new MemoryStream(cartContentAsByteArray), Encoding.Default);
                cart = new Newtonsoft.Json
                        .JsonSerializer()
                        .Deserialize<List<CartItemViewModel>>(new JsonTextReader(reader));
            }

            this.ViewBag.CartItems = cart.Count;
        }
    }
}
