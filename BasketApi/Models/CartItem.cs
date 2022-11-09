namespace BasketApi.Models
{
    public class CartItem
    {
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
