namespace events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiating Handler
            var handler = new DummyEventHandler();

            //Subscribing actions for when event is raised.
            handler.CounterExceedLimits += (sender, args) => System.Console.WriteLine("I Happened");
            handler.CounterExceedLimits += (sender, args) => System.Console.WriteLine("Hey I've been handled");
            
            //Should not raise events.
            handler.IncreaseByAverage(11);
            handler.IncreaseByAverage(11);

            //Should Raise Event
            handler.IncreaseByAverage(100);
        }
    }
}
