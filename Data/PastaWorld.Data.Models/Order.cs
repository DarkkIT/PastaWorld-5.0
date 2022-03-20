namespace PastaWorld.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAnnotationsExtensions;
    using PastaWorld.Data.Common.Models;

    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.Items = new HashSet<CartItem>();
        }

        public ICollection<CartItem> Items { get; set; }

        public string Address { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal MealsPrice { get; set; }

        public string Status { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }

        public string ClientId { get; set; }

        public ApplicationUser Client { get; set; }

        //TODO ADD PHONE, NAME, MealPrice, TotalPrice, email, status\
        //TO FK APPUsers
    }
}
