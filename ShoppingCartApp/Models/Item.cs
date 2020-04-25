namespace ShoppingCartApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public Offer Offer { get; set; }
    }
}
