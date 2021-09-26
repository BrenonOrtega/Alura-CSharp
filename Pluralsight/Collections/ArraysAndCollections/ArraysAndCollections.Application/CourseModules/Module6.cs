using System;
using System.Collections.Generic;
using System.Linq;
using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application.CourseModules
{
    ///<Summary>
    /// This module will deal with multiple dimensions arrays.
    ///</Summary>
    public class Module6 : IExercise
    {
        private readonly IRepository<BusTime> BusTimes;

        public Module6() => BusTimes = new BusTimeRepository();

        public void Run(string[] args)
        {
            MuldimensionalArrayOrSquareArray();
            JaggerArrays();
        }

        private void JaggerArrays()
        {
            var busTimes = BusTimes.Get().ToArray();

            var list = new List<string[]>();

            foreach (var busTime in busTimes)
            {
                var times = busTime.Times;
                foreach (var indexX in Enumerable.Range(0, times.GetLength(0)))
                {
                    var list2 = new List<string>();

                    foreach (var indexY in Enumerable.Range(0, times.GetLength(1)))
                    {
                        list2.Add(times[indexX, indexY]);
                    }

                    list.Add(list2.ToArray());
                }
            }

            list.ForEach(e =>Array.ForEach(e, c => System.Console.WriteLine(c)));
            System.Console.WriteLine(list[1][2]);
        }

        private void MuldimensionalArrayOrSquareArray()
        {
            var busTimes = BusTimes.Get();
            foreach (var busTime in busTimes)
            {
                System.Console.WriteLine("{0}", busTime.Route.ToString());

                var list = new List<string>();

                foreach (var i in Enumerable.Range(0, busTime.Times.GetLength(0)))
                    foreach (var j in Enumerable.Range(0, busTime.Times.GetLength(1)))
                        list.Add(busTime.Times[i, j]);

                list.ForEach(c => System.Console.Write(c.PadLeft(10)));
                System.Console.WriteLine();
            }
        }

    }

}