using System;

namespace events
{
    public class DummyEventArgs : EventArgs
    {
        public DummyEventArgs(string ctorDummyProp, int actualCounter, int increment)
        {
            ActualCounter = actualCounter;
            Increment = increment;
            CtorDummyProp = ctorDummyProp;
        }
        
        public int Increment { get; set; }
        public int ActualCounter { get; set; }
        public string CtorDummyProp { get; set; }
        public string DummyProperty => "Hello I'm Dummy";
    }
}
