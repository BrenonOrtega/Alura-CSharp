using Factory.Application.Models;

namespace Factory.Application.Factories.Invoices
{
    public abstract class InvoiceFactory : IInvoiceFactory
    {
        public IInvoice GetInvoice(Order order)
        {
            var invoice = CreateInvoice(order);
            return invoice;
        }

        protected abstract IInvoice CreateInvoice(Order order1);
    }
}