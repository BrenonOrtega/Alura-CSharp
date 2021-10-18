namespace ArchAspNetDynamoDb.Domain.Models.ValueObjects
{
    public class Person
    {
        public string Name { get; set; }

        public string Document { get; set; }

        public Bank Bank { get; set; }
    }
}