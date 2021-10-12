using Factory.Application.Models;
using Factory.Application.Providers;

namespace Factory.Application.Factories.CountryFactory
{

    public interface ICountryOrderFactory
    {
        ShippingProvider GetShippingProvider(Order order);
        IInvoice GetInvoice(Order order);
        ISummary GetSummary(Order order);
    }

}