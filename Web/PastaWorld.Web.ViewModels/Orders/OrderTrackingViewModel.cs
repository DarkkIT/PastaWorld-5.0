namespace PastaWorld.Web.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.Cart;

    public class OrderTrackingViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal MealsPrice { get; set; }

        public string Status { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public string CliendId { get; set; }

        public string Meals { get; set; }

        public ICollection<CartItemTrackingViewModel> Items { get; set; }
    }
}
