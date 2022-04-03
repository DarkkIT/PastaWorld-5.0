﻿namespace PastaWorld.Web.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PastaWorld.Web.ViewModels.Cart;

    public class OrderPaymentViewModel : OrderViewModel
    {
        public OrderPaymentViewModel()
        {
            this.Addresses = new List<string> { OrderConstants.DeliveryToCustomerAddress, OrderConstants.DeliveryToOurRestaurant };
            this.PaymentMethods = new List<string> { OrderConstants.CashОnDelivery, OrderConstants.WithBankCard };
        }

        [Required]
        public string UserOrOtherAddress { get; set; }

        public decimal CurrentPrice { get; set; }

        [Required]
        public string BankCard { get; set; }

        [Required]
        public bool IsAgreedTermsAndConditions { get; set; }

        [Display(Name = OrderConstants.Town)]
        [Required]
        [MaxLength(30)]
        public string Town { get; set; } = "Варна";

        [Display(Name = OrderConstants.AddressComment)]
        public string AddressComment { get; set; }

        public IList<string> Addresses { get; set; }

        public IList<string> PaymentMethods { get; set; }

        public IList<CartItemViewModel> Items { get; set; }
    }
}
