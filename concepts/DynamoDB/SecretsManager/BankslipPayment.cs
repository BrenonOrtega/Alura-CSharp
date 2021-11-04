using System;

namespace GenericRefundsPOC
{
    public class BankslipPayment : IRefundType
    {
        public string AuthorizationCode { get; set; }
        public string Barcode { get; set; }
        public decimal Amount { get; set; }
        public String IspbReceiver { get; set; }
        public string DocumentNumber { get; set; }
        public string Type => nameof(BankslipPayment);
    }
}