namespace PastaWorld.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PastaWorld.Data.Common.Models;

    public class Meal : BaseDeletableModel<int>
    {
        public Meal()
        {
            this.MealIngredients = new HashSet<MealIngredients>();
        }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public virtual ICollection<MealIngredients> MealIngredients { get; set; }
    }
}
