using System.Collections.Generic;

namespace Outbox.Pattern.Domain
{
    public class Customer
    {
        public string Name { get; set; }= string.Empty;
        public string Surname { get; set; }= string.Empty;
        public string Document { get; set; }= string.Empty;
        public IEnumerable<Billing> Bills { get; set; } = new List<Billing>();
        public static Customer Empty = new();

        private Customer() { }
    }
}