namespace PastaWorld.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using PastaWorld.Data.Common.Models;

    public class CartItem : BaseDeletableModel<int>
    {
        public Meal Meal { get; set; }

        public int Quantity { get; set; }
    }
}
