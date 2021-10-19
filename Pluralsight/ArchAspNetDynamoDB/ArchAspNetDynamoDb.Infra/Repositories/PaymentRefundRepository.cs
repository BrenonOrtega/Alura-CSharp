using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
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

        public Task<IEnumerable<PaymentRefund>> GetByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PaymentRefund>> GetAllAsync(string key)
        {
            var query = _context.QueryAsync<PaymentRefund>(key);

            var payments = await query.GetRemainingAsync();

            return _mapper.Map<IEnumerable<PaymentRefund>>(payments);
        }

        public Task SaveAsync(PaymentRefund paymentRefund)
        {
            var mapped = _mapper.Map<DynamoPaymentRefund>(paymentRefund);
            return _context.SaveAsync(mapped);
        }
    }
}