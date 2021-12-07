using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitor.Elements
{
    public class RetailProduct : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}