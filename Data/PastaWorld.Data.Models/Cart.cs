namespace PastaWorld.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using PastaWorld.Data.Common.Models;

    public class Cart : BaseModel<int>
    {
        public Cart()
        {
            this.Items = new HashSet<CartItem>();
        }

        public ICollection<CartItem> Items { get; set; }

        public string Address { get; set; }

        public decimal DeliveryPrice { get; set; }

    }
}
