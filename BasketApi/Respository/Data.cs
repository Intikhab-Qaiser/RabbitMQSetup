using BasketApi.Models;
using SharedModel;

namespace BasketApi.Repository
{
    public static class Data
    {
        public static List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name = "Item-1", Price=2.5d},
            new Item { Id = 2, Name = "Item-2", Price=5.0d},
            new Item { Id = 3, Name = "Item-3", Price=10.5d},
            new Item { Id = 4, Name = "Item-4", Price=3.5d},
            new Item { Id = 5, Name = "Item-5", Price=2.5d},
        };

        public static List<Cart> carts = new List<Cart>
        {
            new Cart { Id = 1, CartName = "Cart_1" },
            new Cart { Id = 2, CartName = "Cart_2"} ,
            new Cart { Id = 3, CartName = "Cart_3"}
        };

        public static List<CartItem> CartItems = new List<CartItem>
        { 
            new CartItem{ CartId = 1, ItemId = 1, Quantity = 1, UnitPrice = 2.5d},
            new CartItem{ CartId = 1, ItemId = 2, Quantity = 1, UnitPrice = 2.5d },
            new CartItem{ CartId = 2, ItemId = 3, Quantity = 1 , UnitPrice = 5.0d},
            new CartItem{ CartId = 2, ItemId = 4, Quantity = 1 , UnitPrice = 5.0d},
            new CartItem{ CartId = 3, ItemId = 1, Quantity = 1 , UnitPrice = 10.5d},
            new CartItem{ CartId = 3, ItemId = 5, Quantity = 1 , UnitPrice = 10.5d},
            new CartItem{ CartId = 3, ItemId = 4, Quantity = 1 , UnitPrice = 10.5d},
        };



    }
}
