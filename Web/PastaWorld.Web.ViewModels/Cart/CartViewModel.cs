namespace PastaWorld.Web.ViewModels.Cart
{
    using System.Collections.Generic;
    public class CartViewModel
    {
        public ICollection<CartItemViewModel> CartItems { get; set; }
    }
}
