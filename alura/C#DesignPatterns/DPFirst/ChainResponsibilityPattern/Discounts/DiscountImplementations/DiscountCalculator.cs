using System;
using System.Collections.Generic;
using System.Linq;
using dpfirst.ChainResponsibilityPattern.Discounts;

namespace DPFirst.ChainResponsibilityPattern.Discounts    
{
    public class DiscountCalculator
    {
        Stack<IDiscount> discountChain;

        public double GetDiscount(Item item)
        {
            discountChain.TryPeek(out IDiscount discount);
            return discount.Discount(item);
        }
        public double GetDiscount(List<Item> items)
        {
            discountChain.TryPeek(out IDiscount discount);
            return discount.Discount(items);
        }

        public DiscountCalculator()
        {
            discountChain = new Stack<IDiscount>();
            discountChain.Push(new NoDiscount());
        }

        public void AddDiscount(IDiscount discount)
        {
            discountChain.TryPop(out IDiscount lastDiscount);
            discount.NextDiscount = lastDiscount;
            discountChain.Push(lastDiscount);
            discountChain.Push(discount);
        }
    }
}