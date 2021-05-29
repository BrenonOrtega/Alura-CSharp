using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler
{
    public interface IHandler
    {
        IHandler NextHandler { get; }
        public string Execute(RequestTypes type, Account acc);

        void SetNextHandler(IHandler handler);
    }
}