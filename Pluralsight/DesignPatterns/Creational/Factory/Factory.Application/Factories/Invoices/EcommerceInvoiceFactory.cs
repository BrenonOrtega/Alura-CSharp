using System;
using Factory.Application.Models;

namespace Factory.Application.Factories.Invoices
{
    public class EcommerceInvoiceFactory : InvoiceFactory
    {
        protected override IInvoice CreateInvoice(Order order)
        {
            return new EcommerceInvoice();
        }
    }
}