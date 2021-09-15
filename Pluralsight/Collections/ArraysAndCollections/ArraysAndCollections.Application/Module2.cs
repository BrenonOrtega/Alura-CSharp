using ArraysAndCollection.Models;
using ArraysAndCollection.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ArraysAndCollections.Application
{
    ///<Summary>
    ///Module Two is talks about searching data and getting data from arrays.
    ///</Summary>
    public class Module2 : IExercise
    {
        private readonly BusRouteRepository repository;

        public Module2()
        {
            repository = new BusRouteRepository();
        }

        public void Run(string[] args)
        {
            var routes = repository.Get();

            WhereDoYouWannaGoInPokemonWorld(routes);
        }

        private void WhereDoYouWannaGoInPokemonWorld(IEnumerable<BusRoute> routes) =>
            SortingAndFindingWithForeachLoop(routes.ToArray());

        private void SortingAndFindingWithForeachLoop(BusRoute[] busRoutes)
        {
            GreetUser();

            while (true)
            {
                var input = Console.ReadLine().ToLower();
                if (WannaQuit(input))
                    break;

                SearchResult(input);
                ChottoMatte(TimeSpan.FromSeconds(3));
                AskIfWannaSearchAnotherRoute();
            }

            void GreetUser() => PrintWithBars(ConsoleColor.Cyan,
                "HELLO! WELCOME TO POKEMON TRAVELER!!",
                "WHERE WOULD YOU LIKE TO GO TO?" + exitMessage()
            );

            bool WannaQuit(string input) => "exit".Equals(input?.ToLower());

            void SearchResult(string desiredLocation)
            {

                var result = FindBus(desiredLocation);
                var color = result.Equals(BusRoute.Null) ? ConsoleColor.Red : ConsoleColor.Green;

                PrintWithBars(color, "HERE'S WHAT WE FOUND FOR YOUR SEARCH:", result);
            }

            void AskIfWannaSearchAnotherRoute() => 
                PrintWithSpacesAndBars(ConsoleColor.Yellow, "WOULD YOU LIKE TO SEE ANOTHER LOCATION?" + exitMessage());
            
            BusRoute FindBus(string location)
            {
                foreach (var route in busRoutes)
                    if (route.Destination == location || route.Origin == location)
                        return route;

                return BusRoute.Null;
            }
            
            void ChottoMatte(TimeSpan waitTime) => Thread.Sleep(waitTime);

            void PrintWithSpacesAndBars(ConsoleColor color, params object[] messages)
            {
                System.Console.WriteLine();
                PrintWithBars(color, messages); 
                System.Console.WriteLine();
            }

            void PrintWithBars(ConsoleColor color, params object[] messages)
            {
                Console.ForegroundColor = color;

                System.Console.WriteLine("----------------------------------------------------------------");
                Array.ForEach(messages, message => System.Console.WriteLine(message));
                System.Console.WriteLine("----------------------------------------------------------------");  
                
                Console.ForegroundColor = ConsoleColor.White;
            }

            string exitMessage() => "(TYPE \"EXIT\" TO QUIT)";
        }

    }
}