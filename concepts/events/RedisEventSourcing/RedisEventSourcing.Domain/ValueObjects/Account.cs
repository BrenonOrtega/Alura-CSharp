namespace RedisEventSourcing.Domain.ValueObjects
{
    public class Account
    {
        public string Owner { get; set; }
        public string Branch { get; set; }
        public string Number { get; set; }
        public string Bank { get; set; }
    }
}
