namespace PastaWorld.Data.Models
{
    using PastaWorld.Data.Common.Models;

    public class MealIngredients : BaseModel<int>
    {
        public int MealId { get; set; }

        public Meal Meal { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
