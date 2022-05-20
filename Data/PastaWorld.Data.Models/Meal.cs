namespace PastaWorld.Data.Models
{
    using System.Collections.Generic;

    using PastaWorld.Data.Common.Models;

    public class Meal : BaseDeletableModel<int>
    {
        public Meal()
        {
            this.MealIngredients = new HashSet<MealIngredients>();
            this.CartItems = new HashSet<CartItem>();
        }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public bool IsTop { get; set; }

        public virtual ICollection<MealIngredients> MealIngredients { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
