using BasketApi.Models;
using BasketApi.Repository;

namespace BasketApi.Respository
{
    public class BasketRepository : IBasketRepository
    {
        public void AddCartItem(string cartId, CartItem item)
        {
            var cart = Data.carts.Where(c => c.CartName == cartId).Single();
            if (cart == null)
            {
                cart = new Cart { CartName = cartId };
                Data.carts.Add(cart);
            }

            var cartItem = new CartItem { CartId = cart.Id, ItemId = item.ItemId, Quantity = item.Quantity };
            Data.CartItems.Add(cartItem);
        }

        public void DeleteCartItem(string cartId, int itemId)
        {
            var cart = Data.carts.Where(c => c.CartName == cartId).Single();
            
            var cartItem = Data.CartItems.SingleOrDefault(c=>c.ItemId == itemId && c.CartId == cart.Id);
            Data.CartItems.Remove(cartItem);
        }

        public CartVM GetCartModel(string cartId)
        {
            var cart = Data.carts.Where(c => c.CartName == cartId).Single();
            var itemIds = Data.CartItems.Where(c => c.CartId == cart.Id).Select(i => i.ItemId).ToList();

            return new CartVM
            {
                Id = cart.Id,
                items = Data.items.Where(_ => itemIds.Contains(_.Id)).Select(a => a.Name).ToList()
            };
        }

        public List<string> GetItemsCartInCart(string cartId)
        {
            var cart = Data.carts.Where(c => c.CartName == cartId).Single();
            var items = Data.CartItems.Where(c => c.CartId == cart.Id).Select(i => i).ToList();

            var itemsInCart = new List<string>();
            foreach (var item in items)
            {
                itemsInCart.Add("Item ID:" + item.ItemId.ToString() + " Quantity:" + item.Quantity.ToString() + " Unit Price:" + item.UnitPrice.ToString());
            }

            return itemsInCart;
        }

        public List<string> GetCartÌtems(string cartId)
        {
            var cart = Data.carts.Where(c => c.CartName == cartId).Single();
            var itemIds = Data.CartItems.Where(c => c.CartId == cart.Id).Select(i => i.ItemId).ToList();

            return Data.items.Where(_ => itemIds.Contains(_.Id)).Select(a => a.Name).ToList();
        }
    }
}
