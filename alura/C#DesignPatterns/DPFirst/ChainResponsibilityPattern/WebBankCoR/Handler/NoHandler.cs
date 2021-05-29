using System;
using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler
{
    public class NoHandler : BaseHandler
    {
        public NoHandler() : base(null, "")
        {
        }

        public override string Execute(RequestTypes type, Account acc)
        {
            return String.Empty;
        }
    }
}