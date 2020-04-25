using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Repositories
{
    public class CartRepository
    {
        public static Cart _cart;

        public CartRepository()
        {
            _cart = new Cart();
            _cart.Items = new List<CartItem>();
        }

        public void AddItem(string itemId)
        {
            var cartItem = _cart.Items.SingleOrDefault(x => x.Id == itemId);

            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                _cart.Items.Add(new CartItem { Id = itemId, Quantity = 1 });
            }
        }

        public List<CartItem> GetActiveCart()
        {
            return _cart.Items;
        }
    }
}
