using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application.CourseModules
{
    ///<Summary>
    ///This Module talks about <see cref="Queue{T}"/> and <see cref="Stack{T}"/>. 
    ///The application is about a BusStop where passengers arrive and enter the queue for boarding the bus. 
    ///In the Queue order the bus is loaded, arriving at the terminus they land using the <see cref="Stack{T}"/>
    ///</Summary>
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