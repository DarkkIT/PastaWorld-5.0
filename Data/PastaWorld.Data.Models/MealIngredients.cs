using PastaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastaWorld.Data.Models
{
    public class MealIngredients : BaseModel<int>
    {
        public int MealId { get; set; }

        public Meal Meal { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
