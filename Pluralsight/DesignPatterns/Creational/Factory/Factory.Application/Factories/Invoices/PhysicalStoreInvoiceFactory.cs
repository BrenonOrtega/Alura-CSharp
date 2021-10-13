using Factory.Application.Models;

namespace Factory.Application.Factories.Invoices
{
    public class PhysicalStoreInvoiceFactory : InvoiceFactory
    {
        protected override IInvoice CreateInvoice(Order order1)
        {
            return new PhysicalInvoice();
        }
    }
}