using System;
using System.Collections.Generic;
using ArraysAndCollection.Models;

namespace ArraysAndCollections.Application
{
    public class Module1 : IExercise
    {
        public void Run(string[] args)
        {
            var route101 = new BusRoute("Route 101", "Lancaster", "Wembley", 100);
            var route100 = new BusRoute("Route 100", "Celadon", "Ginásio qualquer aí", 100);

            BusRoute[] routes = { route100, route101 };
            List<BusRoute> routesList = new() { route100, route101 };
            Array.ForEach(routes, x => System.Console.WriteLine(x));

            routesList.ForEach(x => Console.WriteLine(x));
        }
    }
}