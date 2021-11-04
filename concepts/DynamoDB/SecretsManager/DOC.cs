using System;

namespace GenericRefundsPOC
{
    public class DOC : IRefundType
    { 
        public DOC() {  }
        public DOC(string transferId, decimal amount, BankAccount account)
        {
            TransferId = transferId;
            Amount = amount;
            Account = account;
        }


        public string TransferId { get; set; }

        public decimal Amount { get; set; }

        public BankAccount Account { get; set; }

        public string Type => nameof(DOC);

        public string DocumentNumber { get; set; }
    }

    public class BankAccount
    {
        public string Branch { get; set; }
        public string Number { get; set; }
        
        public BankAccount()
        {
            
        }

        public BankAccount(string branch, string number)
        {
            Branch = branch;
            Number = number;
        }
    }
}