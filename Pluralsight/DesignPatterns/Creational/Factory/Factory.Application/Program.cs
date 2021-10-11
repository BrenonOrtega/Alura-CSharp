using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Factory.Application.Models;
using Factory.Application.Factories;

namespace Factory.Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("hello world");

            var orderItems = new HashSet<(double, int, string)> 
            {
                (1000, 1, "carro"),
                (500, 2, "celular"),
                (300, 1, "piscina de bolinha")
            };

            var order = new Order("Brazil", orderItems);
            
            var otherOrderItems = orderItems.Union(new HashSet<(double, int, string)>(3)
            {
                (250, 3, "violino"),
                (100, 4, "camisa azul chavosa da nike"),
                (30, 2, "kilo do frango caro demais sehloko")
            });
            
            var otherOrder = new Order("Canada", otherOrderItems);

            ShowAndFinalizeCart(order);
            ShowAndFinalizeCart(otherOrder);
        }

        private static void ShowAndFinalizeCart(Order order)
        {
            var provider = ShippingProviderFactory.Create(order.OriginCountry);
            var shoppingCart = new ShoppingCart(order, provider);

            var label = shoppingCart.Finalize();

            var total = shoppingCart.GetFormattedTotal();

            System.Console.WriteLine(label);
            System.Console.WriteLine(total);
            System.Console.WriteLine(shoppingCart.OrderSummary);
        }
    }
}