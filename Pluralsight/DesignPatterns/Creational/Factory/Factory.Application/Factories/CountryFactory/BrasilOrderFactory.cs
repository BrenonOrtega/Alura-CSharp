using System.Linq;
using Factory.Application.Factories.Invoices;
using Factory.Application.Models;
using Factory.Application.Providers;

namespace Factory.Application.Factories.CountryFactory
{
    public class BrasilOrderFactory : ICountryOrderFactory
    {
        protected ShippingProvider _shippingProvider;

        public IInvoice GetInvoice(Order order)
        {
            var factory = new EcommerceInvoiceFactory();
            var invoice = factory.GetInvoice(order);
            return invoice;
        }

        public ShippingProvider GetShippingProvider(Order order)
        {
            if (_shippingProvider is null)
                _shippingProvider = order.Items.Count() > 10
                    ? new GlobalShippingProvider()
                    : new CorreiosProvider();
            
            return _shippingProvider;
        }

        public ISummary GetSummary(Order order) => new CsvSummary(order);
    }
}