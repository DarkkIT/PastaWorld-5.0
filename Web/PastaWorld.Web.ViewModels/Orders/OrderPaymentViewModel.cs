namespace PastaWorld.Web.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PastaWorld.Common;
    using PastaWorld.Web.ViewModels.Attributes;

    public class OrderPaymentViewModel : OrderViewModel
    {
        public OrderPaymentViewModel()
        {
            this.Addresses = new List<string> { OrderConstants.DeliveryToCustomerAddress, OrderConstants.DeliveryToOurRestaurant };
            this.PaymentMethods = new List<string> { OrderConstants.CashОnDelivery, OrderConstants.WithBankCard };
        }

        [Required]
        public string UserOrOtherAddress { get; set; }

        public bool HasItemsInCart { get; set; }

        [CheckBoxRequired(ErrorMessage = "Моля, съгласете се с Условията на сайта, за да продължите нататък!")]
        public bool IsAgreedTermsAndConditions { get; set; }

        [Display(Name = OrderConstants.Town)]
        [Required]
        [MaxLength(30)]
        public string Town { get; set; } = GlobalConstants.DeliveryCityBg;

        [Display(Name = OrderConstants.AddressComment)]
        public string AddressComment { get; set; }

        public IList<string> Addresses { get; set; }

        public IList<string> PaymentMethods { get; set; }
    }
}
