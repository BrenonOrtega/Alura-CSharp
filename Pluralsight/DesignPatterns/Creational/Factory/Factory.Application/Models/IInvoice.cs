using System;

namespace Factory.Application.Models
{
    public interface IInvoice
    {
        string Id { get; }
        string Name { get; }
    }

    public class EcommerceInvoice : IInvoice
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public string Name => nameof(EcommerceInvoice);
    }

    public class PhysicalInvoice : IInvoice
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public string Name => nameof(PhysicalInvoice);
    }

}
