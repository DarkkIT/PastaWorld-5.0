namespace PastaWorld.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;

    public class OrderViewModel : IMapFrom<Order>
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

        public string ClientId { get; set; }
    }
}
