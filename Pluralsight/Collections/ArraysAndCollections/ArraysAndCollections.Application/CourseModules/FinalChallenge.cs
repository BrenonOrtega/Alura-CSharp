using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application.CourseModules
{
    public class FinalChallenge : IExercise
    {
        private readonly IRepository<Passenger> _repo;
        
        public FinalChallenge()
        {
            _repo = new PassengerRepository();
        }

        public void Run(string[] args)
        {
            var passengers = _repo.Get();
            var enumerator = passengers.GetEnumerator();

            var bus = new ListBus();
            var stop = new BusStop();

            while(enumerator.MoveNext())
                stop.PassengerArrive(enumerator.Current);

            stop.BusArrive(bus);

            bus.ArriveAt("celadon");
            bus.ArriveAt("Viridian");
        }
    }
}