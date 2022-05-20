namespace PastaWorld.Data.Models
{
    using PastaWorld.Data.Common.Models;

    public class CartItem : BaseDeletableModel<int>
    {
        public int Quantity { get; set; }

        public Meal Meal { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
