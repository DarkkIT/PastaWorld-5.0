namespace PastaWorld.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using PastaWorld.Data.Common.Models;

    public class Cart : BaseModel<int>
    {
        public string Address { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal FullPrice { get; set; }
    }
}
