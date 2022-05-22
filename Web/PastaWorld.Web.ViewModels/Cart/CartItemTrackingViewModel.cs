namespace PastaWorld.Web.ViewModels.Cart
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PastaWorld.Data.Models;
    using PastaWorld.Services.Mapping;
    using PastaWorld.Web.ViewModels.Meals;

    public class CartItemTrackingViewModel : IMapFrom<CartItem>
    {
        public int Quantity { get; set; }

        public int MealId { get; set; }

        public MealViewModel Meal { get; set; }

        public int OrderId { get; set; }
    }
}
