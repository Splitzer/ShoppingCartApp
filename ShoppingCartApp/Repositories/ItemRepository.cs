using ShoppingCartApp.Models;
using ShoppingCartApp.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Repositories
{
    public class ItemRepository
    {
        public static List<Item> _cartItems;

        public ItemRepository()
        {
            //Mock Database
            _cartItems = new List<Item>
            {
                new Item
                {
                    Id = "A",
                    Price = 5.00m,
                    Offer = new Offer{ OfferType = OfferType.MultiBuy, Price = 13.00m, Quantity = 3 },
                },
                new Item
                {
                    Id = "B",
                    Price = 3.00m,
                    Offer = new Offer{ OfferType = OfferType.MultiBuy, Price = 4.50m, Quantity = 2 },
                },
                new Item
                {
                    Id = "C",
                    Price = 2.00m,
                    Offer = new Offer{ OfferType = OfferType.RegularPrice },
                },
                new Item
                {
                    Id = "D",
                    Price = 1.50m,
                    Offer = new Offer{ OfferType = OfferType.RegularPrice },
                }
            };
        }

        public Item GetItemFromId(string itemId)
        {
            var item = _cartItems.SingleOrDefault(x => x.Id == itemId);

            return item;
        }
    }
}
