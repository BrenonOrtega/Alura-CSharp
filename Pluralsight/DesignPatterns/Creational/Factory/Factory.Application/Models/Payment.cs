namespace Factory.Application.Models
{
    public class Payment
    {
        public string Type { get; }

        private readonly int amount;

        public Payment(int amount, string type)
        {
            this.amount = amount;
            this.Type = type;
        }
        public static class PaymentType
        {
            public const string Mastercard = "Mastercard";
        }
    }
}