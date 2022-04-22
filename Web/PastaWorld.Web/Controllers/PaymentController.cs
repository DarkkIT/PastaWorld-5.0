namespace PastaWorld.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PastaWorld.Common;
    using PastaWorld.Services.Data.Cart;
    using PastaWorld.Services.Data.Payment;
    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Orders;

    public class PaymentController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IPaymentService paymentService;

        public PaymentController(ICartService cartService, IPaymentService paymentService)
        {
            this.cartService = cartService;
            this.paymentService = paymentService;
        }

        public IActionResult Index()
        {
            var cartIsNotEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

            var cart = new List<CartItemViewModel>();
            var order = new OrderPaymentViewModel();

            if (cartIsNotEmpty && cartContentAsByteArray.Count() > 2)
            {
                cart = this.cartService.DeserializeCartContent(cartContentAsByteArray);
            }
            else
            {
                order.Items = new List<CartItemViewModel>();
                return this.View(order);
            }

            order.Items = cart;
            order.MealsPrice = this.paymentService.GetAllMealsCurrentPrice(cart);
            order.DeliveryPrice = this.paymentService.GetDeliveryPrice(order.MealsPrice);
            order.TotalPrice = this.paymentService.GetTotalPriceWithDelivery(order.DeliveryPrice, order.MealsPrice);
            order.HasItemsInCart = true;

            return this.View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderPaymentViewModel model)
        {
            if (model.UserOrOtherAddress.Equals(OrderConstants.DeliveryToOurRestaurant))
            {
                model.Address = "N/A";
                model.AddressComment = "Без доставка. Поръчката ще се вземе от ресторанта!";
                this.ModelState.ClearValidationState(nameof(model.Address));
            }

            var cartIsNotEmpty = this.HttpContext.Session.TryGetValue("cart", out byte[] cartContentAsByteArray);

            var cart = new List<CartItemViewModel>();

            if (cartIsNotEmpty && cartContentAsByteArray.Count() > 2)
            {
                cart = this.cartService.DeserializeCartContent(cartContentAsByteArray);
            }
            else
            {
                model.Items = new List<CartItemViewModel>();
                return this.View(model);
            }

            model.Items = cart;
            model.Status = GlobalConstants.Ordered;
            model.MealsPrice = this.paymentService.GetAllMealsCurrentPrice(cart);
            model.DeliveryPrice = this.paymentService.GetDeliveryPrice(model.MealsPrice);
            model.TotalPrice = this.paymentService.GetTotalPriceWithDelivery(model.DeliveryPrice, model.MealsPrice);

            var isValid = this.TryValidateModel(model);

            if (!isValid)
            {
                return this.View(model);
            }

            await this.paymentService.AddOrder(model);

            return this.RedirectToAction(nameof(this.Success));
        }

        public IActionResult Success()
        {
            var cart = new List<CartItemViewModel>();

            this.HttpContext.Session.Set("cart", this.cartService.SerializeCartContent(cart));

            return this.View();
        }
    }
}
