using System.Windows.Markup;

namespace DPFirst.ChainResponsibilityPattern.Discounts
{
    public class Item
    {
        public string Name { get; set; }

        public double Value {get; set;}

        public Item(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }

        public static double operator +(Item thisItem, Item otherItem )
        {
            return thisItem.Value + otherItem.Value;
        }
    }
}