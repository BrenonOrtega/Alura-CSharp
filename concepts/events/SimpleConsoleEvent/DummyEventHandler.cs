using System.Collections.Generic;
using System.Linq;

namespace events
{
    public class DummyEventHandler
    {
        public const int MAXIMUM_LIMIT = 20;
        public int Counter { get; set; }
        public delegate void CounterExceed(object sender, DummyEventArgs e);

        public event CounterExceed CounterExceedLimits;

        private void OnCounterExceeding(object sender, DummyEventArgs e)
        {
            Counter = 0;
            var props = e?.GetType().GetProperties();

            foreach (var property in props)
                System.Console.WriteLine("Prop name: {0} - Prop Value: {1}", property.Name, property.GetValue(e));

            CounterExceedLimits(this, e);
        }

        public void IncreaseByAverage(int increments)
        {
            var aggregatedValue = IncrementBy(increments);

            Counter += (int) aggregatedValue.Average();

            if (Counter > MAXIMUM_LIMIT)
                OnCounterExceeding(this, new DummyEventArgs("Just another dummy passed in the constructor", Counter, increments));
        }

        IEnumerable<int> IncrementBy(int increments)
        {
            for (var i = 0; i < increments; i++)
                yield return i;
        }
    }
}
