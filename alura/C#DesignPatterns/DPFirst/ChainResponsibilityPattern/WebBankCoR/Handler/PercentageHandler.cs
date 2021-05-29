using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler
{
    public class PercentageHandler : BaseHandler
    {
        public PercentageHandler(IHandler nextHandler) : base(nextHandler, "%")
        {
        }

        public override string Execute(RequestTypes type, Account acc)
        {
            return type.Equals(RequestTypes.Percentage) 
                                ? acc.ToString().Replace(Account.SEPARATOR, SEPARATOR)
                                : NextHandler?.Execute(type, acc);
        }

        
    }
}