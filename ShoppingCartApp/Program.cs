using ShoppingCartApp.Services;
using System;

namespace ShoppingCartApp
{
    class Program
    {
        private static ShoppingService _shoppingService = new ShoppingService();

        static void Main(string[] args)
        {
            Console.WriteLine("Please add the desired items in the cart. When finished press q! for checkout. \n\nTip: Type an Item name and press enter for every individual item.\n\n---------------------- \n");

            while (true)
            {
                string userInput = Console.ReadLine().ToUpper();
                if (userInput == "Q!") break;

                bool addSuccessful = _shoppingService.AddCartItem(userInput);

                if (addSuccessful)
                {
                    Console.WriteLine("SUCCESS: Item successfully added. Please add another one or checkout.");
                    continue;
                }
                else if(!addSuccessful)
                {
                    Console.WriteLine("FAILURE: Please add a valid item.");
                    continue;
                }
            }

            decimal totalPrice = _shoppingService.Checkout();

            if (totalPrice == 0)
            {
                Console.WriteLine($"The basket is empty. No need to checkout. Thank you for shopping with us.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Checkout SUCCESSFUL, Please pay £{totalPrice}. Thank you for shopping with us.");
                Console.ReadLine();
            }
        }
    }
}
