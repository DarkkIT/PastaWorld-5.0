namespace PastaWorld.Web.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using PastaWorld.Web.ViewModels.Cart;

    public class BaseController : Controller
    {
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

            this.ViewBag.CartItems = cart.Sum(x => x.Quantity);
        }
    }
}
