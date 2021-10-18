using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Domain.Repositories;
using ArchAspNetDynamoDb.Domain.Services;

namespace ArchAspNetDynamoDb.Api.Services
{
    public class PaymentRefundService : IPaymentRefundService
    {
        private readonly IRepository<PaymentRefund> _repository;
        public PaymentRefundService(IRepository<PaymentRefund> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public Task<IEnumerable<PaymentRefund>> GetAllPayments()
        {
            return _repository.GetAll();
        }
        

        public Task<PaymentRefund> GetPayment<T>(params T[] keyFormation)
        {
            if(keyFormation.Length != 2)
                throw new ArgumentException("ARGUMENTS DEMAIS");

            return _repository.FindByHashKey(keyFormation[0], keyFormation[1]);
        }
    }
}