using System.ComponentModel.DataAnnotations;

namespace PastaWorld.Web.ViewModels.Orders
{
    using System.Collections.Generic;

    using PastaWorld.Web.ViewModels.Cart;

    public class OrderPaymentViewModel : OrderViewModel
    {
        public OrderPaymentViewModel()
        {
            this.Addresses = new List<string> { OrderConstants.DeliveryToCustomerAddress, OrderConstants.DeliveryToOurRestaurant };
            this.PaymentMethods = new List<string> { OrderConstants.CashОnDelivery, OrderConstants.WithBankCard };
        }

        public bool IsUserAddress { get; set; }

        public bool IsBankCard { get; set; }

        public bool IsAgreedTermsAndConditions { get; set; }

        [Display(Name = OrderConstants.Town)]
        public string Town { get; set; }

        [Display(Name = OrderConstants.AddressComment)]
        public string AddressComment { get; set; }

        public IList<string> Addresses { get; set; }

        public IList<string> PaymentMethods { get; set; }

        public IList<CartItemViewModel> Items { get; set; }
    }
}
