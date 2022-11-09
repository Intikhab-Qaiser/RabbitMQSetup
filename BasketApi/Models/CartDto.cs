namespace BasketApi.Models
{
    public class CartDto
    {
        public string CartId { get; set; }
        public int ItemId { get; set; }
        public CartItem cartItem { get; set; }
    }
}
