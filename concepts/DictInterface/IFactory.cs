using System;
using System.Collections;

namespace DictInterface
{
    public interface IFactory
    {
        T Create<T>(string requestedProduct);
    }
}