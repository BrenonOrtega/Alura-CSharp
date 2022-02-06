using System.Collections.Generic;
using System.Linq;

namespace Outbox.Pattern.Domain
{
    public class Customer
    {
        public string Name { get; set; }= string.Empty;
        public string Surname { get; set; }= string.Empty;
        public string Document { get; set; }= string.Empty;
        public IEnumerable<Billing> Bills { get; private set; } = new List<Billing>();
        public static Customer Empty = new();

        private Customer() { }

        public Customer(string name, string surname, string document)
        {
            Name = name;
            Surname = surname;
            Document = document;
        }

        public void AddBill(Billing bill) => Bills.Append(bill);
    }
}