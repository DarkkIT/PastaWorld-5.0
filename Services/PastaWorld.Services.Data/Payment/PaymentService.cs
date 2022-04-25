namespace PastaWorld.Services.Data.Payment
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using PastaWorld.Data.Common.Repositories;
    using PastaWorld.Data.Models;
    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Orders;

    public class PaymentService : IPaymentService
    {
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public PaymentService(IDeletableEntityRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task AddOrder(OrderPaymentViewModel model)
        {
            var cartItems = new List<CartItem>();

            foreach (var item in model.Items)
            {
                var meal = new Meal();
                meal.ImageName = item.Meal.ImageName;
                meal.Name = item.Meal.Name;
                meal.Price = item.Meal.Price;

                var cartItem = new CartItem();
                cartItem.Meal = meal;
                cartItem.Quantity = item.Quantity;

                cartItems.Add(cartItem);
            }

            var order = new Order();

            order.Address = model.Address;
            order.AddressComment = model.AddressComment;

            order.PhoneNumber = model.PhoneNumber;
            order.City = model.Town;
            order.Email = model.Email;

            order.FirstName = model.FirstName;
            order.FamilyName = model.FamilyName;
            order.ClientId = model.CliendId;

            order.IsAgreedTermsAndConditions = model.IsAgreedTermsAndConditions;
            order.IsBankCard = false;

            order.Items = cartItems;
            order.MealsPrice = model.MealsPrice;
            order.DeliveryPrice = model.DeliveryPrice;
            order.TotalPrice = model.TotalPrice;

            order.Status = model.Status;

            await this.orderRepository.AddAsync(order);
            await this.orderRepository.SaveChangesAsync();
        }

        public decimal GetTotalPriceWithDelivery(decimal deliveryPrice, decimal currentPrice)
        {
            var totalPrice = deliveryPrice + currentPrice;

            return totalPrice;
        }

        public decimal GetDeliveryPrice(decimal currentPrice)
        {
            var deliveryPrice = 0m;

            if (currentPrice < 10)
            {
                deliveryPrice = 5.00m;
            }

            return deliveryPrice;
        }

        public decimal GetAllMealsCurrentPrice(IList<CartItemViewModel> cart)
        {
            var mealsCurrentPrice = 0m;

            foreach (var item in cart)
            {
                mealsCurrentPrice += this.GetMealTotalPrice(item.Meal.Price, item.Quantity);
            }

            return mealsCurrentPrice;
        }

        public decimal GetMealTotalPrice(decimal mealPrice, decimal quantity)
        {
            var totalPrice = mealPrice * quantity;

            return totalPrice;
        }
    }
}
