using System;
using System.Linq;
using System.Collections.Generic;
using ArraysAndCollection.Models;
namespace ArraysAndCollections.Application
{
    public class Module1 : IExercise
    {
        public void Run(string[] args)
        {
            CollectionInitializers();

            var routes = new[]
            {
                new BusRoute("Route 1", "Pallet", "viridian", 3),
                new BusRoute("Route 2", "Viridian", "Celadon", 3),
                new BusRoute("Route 3", "Celadon", "Lavender", 3),
                new BusRoute("Route 4", "Lavender", "Unova", 3),
            };

            AccessingDataWithIndexers(routes);

            IterationWithForLoop(routes);

            IteratingUsingArrayForEach(routes);

            IteratingUsingListForEach(routes);
        }

        private void CollectionInitializers()
        {
            var route101 = new BusRoute("Route 101", "Lancaster", "Wembley", 100);
            var route100 = new BusRoute("Route 100", "Celadon", "Ginásio qualquer aí", 100);

            BusRoute[] routes = { route100, route101 };
            List<BusRoute> routesList = new List<BusRoute> { route100, route101 };
        }

        private void AccessingDataWithIndexers(BusRoute[] routes)
        {
            PresentFirstObject();
            PresentLastObject();

            void PresentFirstObject()
            {
                var index = new Index(0);
                
                this.Log($"To access an object we can use it's index as follows: ");
                this.Log($"first object: { nameof(index) }: { index } - { nameof(BusRoute) }:{ routes[index] }");
                this.Log();
            }

            void PresentLastObject()
            {
                var index = ^1;

                this.Log($"Index have a class System.Index, we can access the last index of an array as follow: var last = myArray[^1];");
                this.Log($"Last object: { nameof(index) }: { index } (this means \"array.Length - 1\") - { nameof(BusRoute)}:{ routes[index] }");
                this.Log();
            }
        }

        private void IteratingUsingArrayForEach(BusRoute[] routes)
        {
            this.Log("Here we will use the static class Array Method ForEach.");
            this.Log("It takes the array you are iterating and the delegate that should be invoked");
            this.Log("It is powerful since it is performatic and let's us do lots of things with every item in collection");

            Array.ForEach(routes, x => System.Console.WriteLine(x));
            this.Log();
        }

        private void IteratingUsingListForEach(BusRoute[] routes)
        {
           
            var routeList = routes.ToList();

            this.Log("Here we will use the List Class Method ForEach.");
            this.Log("you invoke it directly from the list, passing the predicate that will be invoked.");
            this.Log("It is powerful since it is performatic and let's us do lots of things with every item in collection");
            this.Log("Pretty much like the Array Version of it does, it returns nothing.");
            
            routeList.ForEach(x => Console.WriteLine(x));
            this.Log();
        }

        private void IterationWithForLoop(BusRoute[] routes)
        {
            this.Log("Using for loops we can iterate through the collection onwards or backwards and control what and how we'll handle the data.");
            this.Log("Having the index while we are iterating the collection helps us control the flow of this data.");

            for (int i = 0; i < routes.Length; i++)
                this.Log("Index: {0}, Route: {1}", i, routes[i]);
                
            this.Log();
        }
    }
}