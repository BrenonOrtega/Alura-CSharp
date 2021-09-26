using System;
using System.Collections.Generic;
using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Application.CourseModules
{
    ///<Summary>
    ///Module 3 Is about querying data using Lists, how extensible and easy to use they are.
    ///</Summary>
    public class Module3 : IExercise
    {
        private readonly IBusRouteRepository _repo = new BusRouteRepository();
        public void Run(string[] args)
        {
            var busRouteList = new List<BusRoute>(_repo.Get());

            if (Array.Exists(args, arg => "loops".Equals(arg)))
            {

                this.Log("*****************************************************");
                this.Log("Let's loop through the list using index an for loop.");

                for (int i = 0; i < busRouteList.Count; i++)
                    this.Log("Index:{0} - List Value: {1}", i, busRouteList[i]);

                this.Log("*****************************************************");
                this.Log();
                this.Log("*****************************************************");
                this.Log("Let's loop through the list using foreach loop.");

                foreach (var item in busRouteList)
                    this.Log("Item : {0}", item);

                this.Log("*****************************************************");
            }

            var celadon = "celadon";
            this.Log("*****************************************************");
            this.Log("Let's find an item in the list using the List.Find() method.");
            this.Log($"We'll search for routes that goes with { nameof(celadon) } ");

            var celadonRoute = busRouteList.Find(route => route.Destination.Contains(celadon) || route.Origin.Contains(celadon));

            this.Log("We found this route {0}", celadonRoute);
            this.Log("*****************************************************");



        }
    }
}