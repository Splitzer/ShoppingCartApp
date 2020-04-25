using System;
using ShoppingCartApp.Models;
using ShoppingCartApp.Repositories;

namespace ShoppingCartApp.Services
{
    public class ShoppingService
    {
        private CartRepository _cartRepository;
        private ItemRepository _itemRepository;

        public ShoppingService()
        {
            _cartRepository = new CartRepository();
            _itemRepository = new ItemRepository();
        }

        internal bool AddCartItem(string userInput)
        {
            var itemInfo = _itemRepository.GetItemFromId(userInput);
            if (itemInfo == null)
                return false;

            _cartRepository.AddItem(itemInfo.Id);

            return true;
        }

        internal decimal Checkout()
        {
            var cart = _cartRepository.GetActiveCart();
            decimal sum = 0;

            foreach (var cartItem in cart)
            {
                var itemInfo = _itemRepository.GetItemFromId(cartItem.Id);
                sum += CalculateItemTotalPrice(itemInfo, cartItem.Quantity);
            }

            return sum;
        }

        private decimal CalculateItemTotalPrice(Item itemInfo, int itemQuantity)
        {
            if (itemQuantity == 0)
                return 0;

            switch (itemInfo.Offer.OfferType)
            {
                case Models.Enums.OfferType.RegularPrice:

                    return itemInfo.Price * itemQuantity;
                case Models.Enums.OfferType.MultiBuy:
                    int multiBuyPacks = itemQuantity / itemInfo.Offer.Quantity;
                    int remainderItems = itemQuantity % itemInfo.Offer.Quantity;

                    var totalPrice = (itemInfo.Offer.Price * multiBuyPacks) + (itemInfo.Price * remainderItems);

                    return totalPrice;
                default:
                    throw new NotImplementedException("Offer type not implemented");
            }
        }
    }
}
