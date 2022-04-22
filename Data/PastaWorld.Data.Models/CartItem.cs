namespace PastaWorld.Data.Models
{
    using PastaWorld.Data.Common.Models;

    public class CartItem : BaseDeletableModel<int>
    {
        public Meal Meal { get; set; }

        public int Quantity { get; set; }
    }
}
