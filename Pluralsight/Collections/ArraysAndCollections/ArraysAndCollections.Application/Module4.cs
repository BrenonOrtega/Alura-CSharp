using ArraysAndCollections.Models.Shared;
using ArraysAndCollections.Models;
using System.Linq;
using System.Collections.Generic;

namespace ArraysAndCollections.Application
{
    public class Module4 : IExercise
    {
        private readonly BusRouteRepository _repo;

        public Module4() => _repo = new BusRouteRepository();

        public void Run(string[] args)
        {
            var routes = _repo.Get().ToList();
            var busRouteDictionary = new Dictionary<int, BusRoute>(routes.Select((route, index) => KeyValuePair.Create(index, route)));

            foreach (var key in busRouteDictionary.Keys)
            {
                this.Log($"Key:{key} - Value: {busRouteDictionary[key]}");
            }
        }
    }
}