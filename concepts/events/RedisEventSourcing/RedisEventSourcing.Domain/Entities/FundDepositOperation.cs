using System;
using RedisEventSourcing.Domain.ValueObjects;
using RedisEventSourcing.Domain.Entities.Shared;

namespace RedisEventSourcing.Domain.Entities
{
    public class FundDepositOperation : BaseEntity<long>
    {
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public string Channel { get; set; }
    }
}
