using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler
{
    public class XMLHandler : BaseHandler
    {
        public XMLHandler(IHandler nextHandler) : base(nextHandler, "")
        {
        }

        public override string Execute(RequestTypes type, Account acc)
        {   
             
            return type.Equals(RequestTypes.XML) 
                            ? createXML(acc)
                            : NextHandler?.Execute(type, acc);
        }

        private string createXML(Account acc)
        {   return $@"  <Account>
                            <Name>{acc.Name}</Name>
                            <Balance>{acc.Balance}</Balance>
                        </Account>".Replace(" ", String.Empty);    
        }
    }
}