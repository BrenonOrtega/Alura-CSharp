using System;

namespace EventsAndDelegates.Console
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MyEventRaiser
    {
        public event Func<string, string> MyEvent;
        
    }
}
