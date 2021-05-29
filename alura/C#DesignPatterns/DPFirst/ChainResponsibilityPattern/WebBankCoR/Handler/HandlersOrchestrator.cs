using System;
using System.Collections.Generic;
using System.Linq;
using DPFirst.ChainResponsibilityPattern.WebBankCoR.Requests;

namespace DPFirst.ChainResponsibilityPattern.WebBankCoR.Handler
{
    public class HandlersOrchestrator
    {
        List<IHandler> Handlers;

        public string HandleRequest(RequestTypes request, Account acc)
        {
            return Handlers.First().Execute(request, acc);
        }

        public HandlersOrchestrator(params IHandler[] handlers)
        {
            Handlers = new List<IHandler>(handlers.Count() + 1);
            Handlers.AddRange(handlers.ToList());
            Handlers.Add(new NoHandler());
            ChainHandlers();
        }

        public void AddHandler(IHandler handler)
        {
            Handlers.Prepend(handler);
            ChainHandlers();
        }
        private void ChainHandlers()
        {
            for(var i = 0; i < Handlers.Count; i++)
            {  
                try 
                {  Handlers[i].SetNextHandler(Handlers[i+1]); } 
                catch(Exception)
                { break; }       
            }
        }
    }
}