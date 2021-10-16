namespace MassTransitConsumerInjection
{
    public class PaymentRefund
    {
        public PaymentRefund(string amount, string sender, string barcode)
        {
            Amount = amount;
            Sender = sender;
            Barcode = barcode;
        }

        public override string ToString() => $"Amount: {Amount}, Sender: {Sender}, Barcode: {Barcode}";
        public string Amount;
        public string Sender;
        public string Barcode;
    }
}