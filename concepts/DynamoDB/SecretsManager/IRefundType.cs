using System;

namespace GenericRefundsPOC
{
    public interface IRefundType
    {
        public string Type { get; }
        public decimal Amount { get; set; }
        public string DocumentNumber { get; set; }
    }
}