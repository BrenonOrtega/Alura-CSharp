using System.Collections.Generic;
using System.Linq;

namespace Factory.Application.Models
{
    public class Order
    {
        public string OriginCountry { get; set; }
        public Order(string originCountry, IEnumerable<(double price, int quantity, string item)> items)
        {
            this.OriginCountry = originCountry;
            Items = items.ToHashSet();
        }

        public double SubTotal => Items.Sum(x => x.price * x.quantity);
        public HashSet<(double price, int quantity, string item)> Items { get; set; }
    }
}