using PastaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastaWorld.Data.Models
{
    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.MealIngredients = new HashSet<MealIngredients>();
        }

        public string Name { get; set; }

        public virtual ICollection<MealIngredients> MealIngredients { get; set; }
    }
}
