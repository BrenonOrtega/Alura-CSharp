using System.Collections.Generic;

namespace DPFirst.ChainResponsibilityPattern.Discounts
{
    public interface IDiscount
    {
        IDiscount NextDiscount { get; set; }

        double Discount(Item item);

        double Discount(List<Item> items);
    }
}