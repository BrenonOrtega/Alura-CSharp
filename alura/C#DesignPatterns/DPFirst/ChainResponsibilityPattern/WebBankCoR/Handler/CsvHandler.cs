using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler
{
    public class CsvHandler : BaseHandler
    {
        public CsvHandler(IHandler nextHandler) : base(nextHandler, ",")
        {
        }

        public override string Execute(RequestTypes type, Account acc)
        {
            return type.Equals(RequestTypes.CSV)
                        ? acc.ToString().Replace(Account.SEPARATOR, SEPARATOR)
                        : NextHandler?.Execute(type, acc) ;
        }
    }
}