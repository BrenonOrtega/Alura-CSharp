using Factory.Application.Factories.CountryFactory;
using Factory.Application.Factories.Invoices;
using Factory.Application.Factories.Shipping;
using Factory.Application.Factories.Summary;
using Factory.Application.Providers;

namespace Factory.Application.Models
{
    public class ShoppingCart
    {
        private readonly ICountryOrderFactory _countryOrderFactory;

        public double Total { get; private set; }
        public Order Order { get; set; }


        public ShoppingCart(Order order, ICountryOrderFactory countryOrderFactory)
        {
            this.Order = order;
            _countryOrderFactory = countryOrderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = _countryOrderFactory.GetShippingProvider(Order);
            Total = Order.SubTotal + shippingProvider.Fee;
            return shippingProvider.CreateLabel(Order);
        }

        public IInvoice GetInvoice() => _countryOrderFactory.GetInvoice(Order);

        private string GetFormattedTotal(double value)
        {
            var shippingProvider = _countryOrderFactory.GetShippingProvider(Order);
            return Total.ToString("C2", shippingProvider.Culture);
        }
        public string GetFormattedTotal() => GetFormattedTotal(Total);

        public string OrderSummary =>
            _countryOrderFactory.GetSummary(Order).Stringify(GetFormattedTotal());
    }
}