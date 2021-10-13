using System;

namespace ExampleDomain
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
