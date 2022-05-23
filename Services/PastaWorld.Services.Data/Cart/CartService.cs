namespace PastaWorld.Services.Data.Cart
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Newtonsoft.Json;
    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Meals;

    public class CartService : ICartService
    {
        public List<CartItemViewModel> AddItemToCart(MealViewModel meal, List<CartItemViewModel> cart)
        {
            if (cart.Any(x => x.Id == meal.Id))
            {
                cart.FirstOrDefault(x => x.Id == meal.Id).Quantity++;
            }
            else
            {
                var cartItem = new CartItemViewModel
                {
                    Id = meal.Id,
                    ImageName = meal.ImageName,
                    Name = meal.Name,
                    Price = meal.Price,
                    Quantity = 1,
                };

                cart.Add(cartItem);
            }

            return cart;
        }

        public List<CartItemViewModel> DeserializeCartContent(byte[] cartContentAsByteArray)
        {
            var reader = new StreamReader(new MemoryStream(cartContentAsByteArray), Encoding.Default);
            return new Newtonsoft.Json
                .JsonSerializer()
                .Deserialize<List<CartItemViewModel>>(new JsonTextReader(reader));
        }

        public List<CartItemViewModel> RemoveItemFromCart(int id, List<CartItemViewModel> cart)
        {
            if (cart.Any(x => x.Id == id))
            {
                var cartItem = cart.FirstOrDefault(x => x.Id == id);

                if (cartItem.Quantity == 1)
                {
                    cart.Remove(cartItem);
                }
                else if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
            }

            return cart;
        }

        public byte[] SerializeCartContent(List<CartItemViewModel> cart)
        {
            var serializedCart = JsonConvert.SerializeObject(cart);
            return Encoding.UTF8.GetBytes(serializedCart);
        }
    }
}
