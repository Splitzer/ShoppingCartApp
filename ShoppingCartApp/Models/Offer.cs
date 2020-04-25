using ShoppingCartApp.Models.Enums;

namespace ShoppingCartApp.Models
{
    public class Offer
    {
        public OfferType OfferType { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}