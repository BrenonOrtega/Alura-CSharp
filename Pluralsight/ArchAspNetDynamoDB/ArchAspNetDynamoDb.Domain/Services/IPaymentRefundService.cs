using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchAspNetDynamoDb.Domain.Models.Entities;

namespace ArchAspNetDynamoDb.Domain.Services
{
    public interface IPaymentRefundService
    {
        Task<IEnumerable<PaymentRefund>> GetAllPayments();
        Task<PaymentRefund> GetPayment<T>();
    }
}