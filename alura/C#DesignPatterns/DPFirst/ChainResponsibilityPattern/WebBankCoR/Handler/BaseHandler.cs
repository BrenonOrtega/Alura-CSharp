using System;
using System.Reflection.Metadata;
using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler
{
    public abstract class BaseHandler : IHandler
    {
        protected BaseHandler(IHandler nextHandler, string separator)
        {
            NextHandler = nextHandler;
            SEPARATOR = separator;
        }

        protected string SEPARATOR {get;}
        public IHandler NextHandler { get; private set; }

        public abstract string Execute(RequestTypes type, Account acc);

        public void SetNextHandler(IHandler nextHandler)
        {
            NextHandler = nextHandler;
        }
    }
}