using System;
using System.Collections.Generic;
using System.Linq;
using DPFirst.ChainResponsibilityPattern.Discounts;

namespace dpfirst.ChainResponsibilityPattern.Discounts
{
    public class PairDiscount : IDiscount
    {
        
        public PairDiscount(Item item1, Item item2)
        {
            Pair = KeyValuePair.Create(item1.Name, item2.Name);
        }
        public KeyValuePair<string, string> Pair;
    
        public IDiscount NextDiscount { get; set; }

        public double Discount(Item item)
        {
            return NextDiscount.Discount(item);
        }

        public double Discount(List<Item> items)
        {
            var pairSell = items.Where(x => Pair.Key.Equals(x.Name) || Pair.Value.Equals(x.Name));

            return pairSell.Count() >= 2
                        ? pairSell.Sum(x => x.Value) * 0.05
                        : NextDiscount.Discount(items);
        }
    }
}