namespace PastaWorld.Web.ViewModels.Cart
{
    using PastaWorld.Web.ViewModels.Meals;

   public class CartItemViewModel
    {
        public MealAsCartItemViewModel Meal { get; set; }

        public int Quantity { get; set; }
    }
}
