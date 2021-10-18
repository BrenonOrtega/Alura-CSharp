using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Domain.Repositories;
using ArchAspNetDynamoDb.Infra.DynamoDb;
using ArchAspNetDynamoDb.Infra.DynamoDb.Mappers;
using ArchAspNetDynamoDb.Infra.DynamoDb.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchAspNetDynamoDb.Infra.Repositories
{
    public class PaymentRefundRepository : IRepository<PaymentRefund>
    {
        private readonly IMapper _mapper;
        private readonly IDynamoDBContext _context;

        public PaymentRefundRepository(IMapper mapper, IDynamoDBContext context)
        {
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public Task<PaymentRefund> FindByHashKey<TPartitionKey, TSortKey>(TPartitionKey partitionkey, TSortKey sortKey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PaymentRefund>> GetAll()
        {
            Task<List<DynamoPaymentRefund>> paymentsTask = GetPaymentsAsync();
            var payments = await paymentsTask;

            return _mapper.Map<IEnumerable<PaymentRefund>>(payments);
        }

        public async Task<List<DynamoPaymentRefund>> GetPaymentsAsync()
        {
            var query = _context.QueryAsync<DynamoPaymentRefund>("2021-10-18", QueryOperator.BeginsWith, new List<object> { DateTime.Today.ToString() });

            return await query.GetRemainingAsync();
        }

        public Task SaveAsync(PaymentRefund paymentRefund)
        {
            var mapped = _mapper.Map<DynamoPaymentRefund>(paymentRefund);
            return _context.SaveAsync(mapped);
        }
    }
}