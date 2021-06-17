using System;
using System.Collections.Generic;
using DelegateLib;

namespace DelegateConsole
{
    class Program
    {
        static ShoppingCart cart = new();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            populateShoppingCart();

            System.Console.WriteLine(@$"Total value of this cart is { cart.GeneterateTotal( ShowDiscount, 
                                                                                            CalculateDiscount,
                                                                                            AlertUser):C2}.");

            System.Console.WriteLine();

            var subtotalCart2 = cart.GeneterateTotal(x => System.Console.WriteLine($"subtotal for cart 2 is { x:C2}"),
                                            ((products , x) => products.Count > 3 ? x * 0.7M : x * 0.9M),
                                            (message) => System.Console.WriteLine("message"));

            System.Console.WriteLine($"the subtotal for cart2 is {subtotalCart2:c2}");
        }

        static void ShowDiscount(decimal subTotal)
        {
            System.Console.WriteLine($"Your Discount is { subTotal:C2}");
        }

        private static decimal CalculateDiscount(List<ProductModel> products, decimal subTotal)
        {
            if (subTotal > 100 ){ return 0.80M * subTotal; }
            if (subTotal > 80 ) { return 0.85M * subTotal; }
            if (subTotal > 70 ) { return 0.90M * subTotal; }
            if (subTotal > 50 ) { return 0.95M * subTotal; }
            return subTotal;           
        }

        private static void AlertUser(string message)
        {
            System.Console.WriteLine(message);
        }

        static void populateShoppingCart()
        {
            cart.products.Add(new ProductModel { Name="Candy", Price=20 });
            cart.products.Add(new ProductModel { Name="Cigarrete", Price=31  });
            //cart.products.Add(new ProductModel { Name="Whey protein", Price=40M  });
        }
    }
}
