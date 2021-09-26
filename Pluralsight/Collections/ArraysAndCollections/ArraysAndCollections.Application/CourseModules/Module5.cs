using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;
using static ArraysAndCollections.Application.Helper;

namespace ArraysAndCollections.Application.CourseModules
{
    ///<Summary>
    ///Module 5 is all about <see cref="HashSet{T}"/> and why we should use it whenever 
    ///operating on whole collections, joining, intercepting sets and etc.
    ///</Summary>
    public class Module5 : IExercise
    {
        private readonly IBusRouteRepository _repo = new BusRouteRepository();
        public void Run(string[] args)
        {
            var routes = _repo.Get();
            SearchIntersection(routes);
            //SearchMultiple(routes);
        }


        private void SearchIntersection<T>(IEnumerable<T> routes)
        {
            Console.WriteLine("Where you like to go in pokemon world?");
            Console.WriteLine("From where are you travelling?");

            var origin = Console.ReadLine();
 
            this.Log("To where are you travelling?");
            var destination = Console.ReadLine();
            

           /*  var destination = "route";
            var origin = "route"; */

            var originRoutes = _repo.FindBus(origin);
            var destinationRoutes = _repo.FindBus(destination);

            var hashSet = new HashSet<BusRoute>(originRoutes);
            hashSet.IntersectWith(destinationRoutes);

            var color = ConsoleColor.Red;
            var msg = "No item found for collection {0}";

            if(hashSet.Count > 0)
            {
                color = ConsoleColor.Blue;
                msg = "here's the query found itens";
            }


            PrintWithBars(color, string.Format(msg, hashSet));
        } 
    }
}