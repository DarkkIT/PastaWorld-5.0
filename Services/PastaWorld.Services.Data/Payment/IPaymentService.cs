namespace PastaWorld.Services.Data.Payment
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Orders;

    public interface IPaymentService
    {
        Task AddOrder(OrderPaymentViewModel model);

        decimal GetTotalPriceWithDelivery(decimal deliveryPrice, decimal currentPrice);

        decimal GetDeliveryPrice(decimal currentPrice);

        decimal GetAllMealsCurrentPrice(IList<CartItemViewModel> cart);

        decimal GetMealTotalPrice(decimal mealPrice, decimal quantity);
    }
}
