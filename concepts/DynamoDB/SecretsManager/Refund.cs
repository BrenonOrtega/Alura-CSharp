using System;
using Amazon.DynamoDBv2.DataModel;

namespace GenericRefundsPOC
{
    public interface IRefund
    {
        [DynamoDBRangeKey]
        string Id { get; }

        [DynamoDBHashKey]
        string RefundType { get; }
    }

    [DynamoDBTable("Refunds")]
    public class Refund<T> : IRefund where T : class, IRefundType, new()
    {
        [DynamoDBRangeKey]
        public string Id { get; set; }

        string _refundType;
        [DynamoDBHashKey]
        public string RefundType { get => _refundType; set => _refundType = value; }

        public T RefundInfo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Refund()
        {
            _refundType = typeof(T).Name;
        }
    }

    public class BankslipRefund : Refund<BankslipPayment>
    {

    }

    public class DocRefund : Refund<DOC>
    {

    }

}