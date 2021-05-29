using System;
using System.Collections.Generic;
using DPFirst.ChainResponsibilityPattern.Discounts;

namespace dpfirst.ChainResponsibilityPattern.Discounts
{
    public class NoDiscount : IDiscount
    {
        public IDiscount NextDiscount { get=> throw new InvalidOperationException(); set => value = null; }

        public double Discount(Item item)
        {
            System.Console.WriteLine("No discount applyed");
            return 0;
        }

        public double Discount(List<Item> items)
        {
            System.Console.WriteLine("No discount applyed");
            return 0;
        }
    }
}