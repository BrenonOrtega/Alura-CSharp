using System.Collections.Generic;
using System.Linq;

namespace DPFirst.ChainResponsibilityPattern.Discounts
{
    public class ThreeHundredDiscount : IDiscount
    {
        public IDiscount NextDiscount { get; set ; }

        public double Discount(Item item)
        {
            var value = item.Value;
            if (value > 300) 
            {
                System.Console.WriteLine("applyed 300 discount ");    
                return value * 0.1 ;
            }

            System.Console.WriteLine("tryed 300 discount, going next.");
            return NextDiscount.Discount(item);
        }

        public double Discount(List<Item> items)
        {
            var discount = items.Where(item => item.Value > 300)
                                    .Sum(x => x.Value) * 0.1; 

            return discount > 0 ? discount : NextDiscount.Discount(items);
        }
    }
}