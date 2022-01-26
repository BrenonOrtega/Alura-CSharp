using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IVisitor<TVisitable> where TVisitable : IVisitable
    {
        void Visit(TVisitable visitable);
    }
}