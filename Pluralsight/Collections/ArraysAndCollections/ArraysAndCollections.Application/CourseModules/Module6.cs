using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application.CourseModules
{
    public class Module6 : IExercise
    {
        private readonly IRepository<BusTime> BusTimes;
        public Module6()
        {
            BusTimes = new BusTimeRepository();
        }

        public void Run(string[] args)
        {
            var busTimes = BusTimes.Get();

            foreach (var busTime in busTimes)
            {
                System.Console.WriteLine("{0}", busTime.Route.ToString());
                for (int i = 0; i < busTime.Times.GetLength(1); i++)
                {
                    System.Console.Write("{0}", string.Join(",", busTime.Times.GetValue(0, i)).PadRight(10));
                }
                System.Console.WriteLine();
            }
        }
    }
}