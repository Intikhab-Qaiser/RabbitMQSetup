using BasketApi.Models;

namespace BasketApi.Respository
{
    public interface IBasketRepository
    {
        CartVM GetCartModel(string cartId);
        List<string> GetCartÌtems(string cartId);
        void AddCartItem(string cartId, CartItem item);
        void DeleteCartItem(string cartId, int itemId);

        List<string> GetItemsCartInCart(string cartId);

    }
}
