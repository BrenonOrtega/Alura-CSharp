using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application.CourseModules
{
    ///<Summary>
    ///Module 8 is all about LinkedLists and adding, removing data efficiently.
    ///Here will implement passengers boarding the bus and only landing at their
    ///Destination places.
    ///</Summary>
    public class Module8 : IExercise
    {
        private readonly IRepository<Passenger> _repo;
        public Module8()
        {
            _repo = new PassengerRepository();
        }

        public void Run(string[] args)
        {
            var passengers = _repo.Get();
            var enumerator = passengers.GetEnumerator();

            var bus = new LinkedListBus();
            var stop = new BusStop();

            while(enumerator.MoveNext())
                stop.PassengerArrive(enumerator.Current);

            stop.BusArrive(bus);

            bus.ArriveAt("celadon");
            bus.ArriveAt("Viridian");
        }
    }
}