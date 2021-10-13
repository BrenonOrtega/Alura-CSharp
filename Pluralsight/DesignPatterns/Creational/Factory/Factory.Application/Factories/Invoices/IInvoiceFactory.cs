using System;
using Factory.Application.Models;

namespace Factory.Application.Factories.Invoices
{
    public interface IInvoiceFactory
    {
        IInvoice GetInvoice(Order order);
    }
}