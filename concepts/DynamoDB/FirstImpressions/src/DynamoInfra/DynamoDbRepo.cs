using System;
using Amazon.DynamoDBv2.DataModel;
using ExampleDomain;
using ExampleDomain.Repositories;

namespace DynamoInfra
{
    public class DynamoDbRepo : IRepository<RefundPayment, string>
    {
        IDynamoDBContext _context;

        public DynamoDbRepo(IDynamoDBContext context)
        {
            _context = context;
        }

        public RefundPayment GetAsync(Predicate<RefundPayment> filter)
        {
            throw new NotImplementedException();
        }

        public RefundPayment GetByIndexKeyAsync(string hashKey)
        {
            throw new NotImplementedException();
        }
    }
}
