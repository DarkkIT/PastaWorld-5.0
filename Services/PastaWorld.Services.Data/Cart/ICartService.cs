namespace PastaWorld.Services.Data.Cart
{
    using PastaWorld.Web.ViewModels.Cart;
    using PastaWorld.Web.ViewModels.Meals;
    using System.Collections.Generic;

    public interface ICartService
    {
        List<CartItemViewModel> DeserializeCartContent(byte[] cartContentAsByteArray);

        byte[] SerializeCartContent(List<CartItemViewModel> cart);

        List<CartItemViewModel> AddItemToCart(MealAsCartItemViewModel meal, List<CartItemViewModel> cart);

        List<CartItemViewModel> RemoveItemFromCart(int id, List<CartItemViewModel> cart);
    }
}
