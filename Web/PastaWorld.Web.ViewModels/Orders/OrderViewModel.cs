using System.ComponentModel.DataAnnotations;

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

        [Display(Name = OrderConstants.Address)]
        public string Address { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal MealsPrice { get; set; }

        public string Status { get; set; }

        [Display(Name = OrderConstants.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = OrderConstants.FirstName)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = OrderConstants.FamilyName)]
        [Required]
        public string FamilyName { get; set; }

        [Display(Name = OrderConstants.Email)]
        [Required]
        public string Email { get; set; }

        public string CliendId { get; set; }
    }
}
