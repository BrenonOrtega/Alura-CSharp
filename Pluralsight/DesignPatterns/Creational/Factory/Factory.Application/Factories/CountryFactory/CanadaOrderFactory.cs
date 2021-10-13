using System;
using Factory.Application.Factories.Invoices;
using Factory.Application.Models;
using Factory.Application.Providers;

namespace Factory.Application.Factories.CountryFactory
{
    public class CanadaOrderFactory : ICountryOrderFactory
    {
        public IInvoice GetInvoice(Order order)
        {
            var factory = new PhysicalStoreInvoiceFactory();
            var invoice = factory.GetInvoice(order);
            return invoice;
        }

        public ShippingProvider GetShippingProvider(Order order)
        {
            return new CanadaShippingProvider();
        }

        public ISummary GetSummary(Order order)
        {
            return new FileSummary(order);
        }
    }
}