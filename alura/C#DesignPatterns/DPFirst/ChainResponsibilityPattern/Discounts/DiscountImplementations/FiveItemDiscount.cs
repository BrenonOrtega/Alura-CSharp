using System.Collections.Generic;
using System.Linq;

namespace DPFirst.ChainResponsibilityPattern.Discounts
{
    public class FiveItemDiscount : IDiscount
    {
        public FiveItemDiscount() 
        { 

        }
        public FiveItemDiscount(IDiscount nextDiscount)
        {
            this.NextDiscount = nextDiscount;
        }
        public IDiscount NextDiscount { get; set; }

        public double Discount(Item item)
        {   System.Console.WriteLine("a single item cannot apply 5 item discount");
            return NextDiscount.Discount(item);
        }

        public double Discount(List<Item> items)
        {   
            if (items.Count < 5)
            { 
                System.Console.WriteLine("less than 5 going next");
                return NextDiscount.Discount(items);
            }
            System.Console.WriteLine("applying 5 item discount");  
            return items.Sum(item => item.Value) * 0.05;
        }
    }
}