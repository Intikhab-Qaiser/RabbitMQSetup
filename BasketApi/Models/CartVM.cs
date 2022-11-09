namespace BasketApi.Models
{
    public class CartVM
    {
        public int Id { get; set; }
        public List<string> items { get; set; }

        public double price { get; set; }
    }
}
