using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application.CourseModules
{
    public class Module7 : IExercise
    {
        private readonly IRepository<Passenger> _repo;
        public Module7()
        {
            _repo = new PassengerRepository();
        }

        public void Run(string[] args)
        {
            var passengers = _repo.Get();
            var enumerator = passengers.GetEnumerator();

            var bus = new Bus();
            var stop = new BusStop();

            while(enumerator.MoveNext())
                stop.PassengerArrive(enumerator.Current);

            stop.BusArrive(bus);

            bus.ArriveAtTerminus();
        }
    }
}