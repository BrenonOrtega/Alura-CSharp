using System;
using System.Linq;
using System.Text.Json;
using Factory.Application.Factories;
using Factory.Application.Providers;

namespace Factory.Application.Models
{
    public class ShoppingCart
    {
        private readonly ShippingProvider _shippingProvider;
        private readonly ShippingProviderFactory _shippingProviderFactory;

        public double Total { get; private set; }
        public Order Order { get; set; }
        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            this.Order = order;
            _shippingProviderFactory = shippingProviderFactory;
            _shippingProvider = _shippingProviderFactory.GetShippingProvider(Order.OriginCountry);
        }

        public string Finalize()
        {
            Total = Order.SubTotal + _shippingProvider.Fee;
            return _shippingProvider.CreateLabel(Order);
        }

        private string GetFormattedTotal(double value) => Total.ToString("C2", _shippingProvider.Culture);
        public string GetFormattedTotal() => GetFormattedTotal(Total);

        public string OrderSummary =>
            JsonSerializer.Serialize(new
            {
                Order = new { Order.OriginCountry, SubTotal = GetFormattedTotal(Order.SubTotal), Total = GetFormattedTotal() },
                Items = Order.Items.Select(x => new { x.item, x.price, x.quantity }),
            },
             new JsonSerializerOptions { WriteIndented = true });
    }
}