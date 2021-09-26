using ArraysAndCollections.Models.Shared;
using ArraysAndCollections.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ArraysAndCollections.Application.CourseModules
{
    ///<Summary>
    ///<see cref="Module4"/> we learned about <seealso cref="Dictionary{T}"/> 
    ///And why we should prefer it whenever we want to efficiently query and find data.
    ///</Summary>
    public class Module4 : IExercise
    {
        private readonly IBusRouteRepository _repo;

        public Module4() => _repo = new BusRouteRepository();

        public void Run(string[] args)
        {
            var routes = _repo.Get().ToList();
            var busRouteDictionary = new Dictionary<int, BusRoute>(routes.Select((route, index) => KeyValuePair.Create(index, route)));

            this.Log("Enumerating the dictionary keys and acessing then using [] notation");
            foreach (var key in busRouteDictionary.Keys)
                this.Log($"Key:{key} - Value: {busRouteDictionary[key]}");


            var nonExistentKey = 10000;
            var existentKey = 1;

            AcessingNonExistentKeysThrowsException(busRouteDictionary, nonExistentKey);
            ContainsKeyAndTryGetValueMethods(busRouteDictionary, nonExistentKey, existentKey);
        }

        private void ContainsKeyAndTryGetValueMethods(Dictionary<int, BusRoute> busRouteDictionary, int nonExistentKey, int existentKey)
        {
            
            this.Log();
            this.Log("We have 2 ways to find if data is in dictionary. Using the method ContainsKey or" + 
                "\nContainsValue for searching for a data, and the lookup for it.");

            this.Log("We can use the Method above and if return true we use it with the indexer operator (DON'T RECOMMEND IT SINCE IT'S 2 QUERIES)");
            
            this.Log("And we can use have the 'TryGetValue' Method that returns a bool and puts the fought data" +
                "\nin an out variable with the result if found, not needing 2 access");

            var exists = busRouteDictionary.TryGetValue(nonExistentKey, out BusRoute inexistentRoute);
            var action = Exists(exists, inexistentRoute);
            action();

            exists = busRouteDictionary.TryGetValue(existentKey, out BusRoute existentRoute);
            action = Exists(exists, existentRoute);
            action();
        }

        private void AcessingNonExistentKeysThrowsException(Dictionary<int, BusRoute> busRouteDictionary, int nonExistentKey)
        {
            this.Log("Now Lets try searching for a value that doesn't exist - key{0}", nonExistentKey);
            try
            {
                var value = busRouteDictionary[nonExistentKey];
            }
            catch (Exception e)
            {
                this.Log(e);
                this.Log("As we can see, accessing keys that does not exist throws exceptions for us.");
            }
        }

        private Action Exists(bool exists, params object[] args) => exists switch
        {
            false => () => this.Log("As we see the TryGetValue returns {0} if it does not find anything.\n", exists),
            true => () => this.Log("if it finds anything, then it return {0} " + 
                "and puts the result in the object passed with out param \n{1}",exists, string.Join(',', args))
        };
    }
}