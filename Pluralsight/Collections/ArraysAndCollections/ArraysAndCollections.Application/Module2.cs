using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;
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

        public Module2() => repository = new BusRouteRepository();

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
                ChottoMatte(TimeSpan.FromSeconds(2));
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
                var routes = result.Select(route => route.ToString()).ToArray();

                PrintWithBars(color, "HERE'S WHAT WE FOUND FOR YOUR SEARCH:", routes);
            }

            void AskIfWannaSearchAnotherRoute() =>
                PrintWithSpacesAndBars(ConsoleColor.Yellow, "WOULD YOU LIKE TO SEE ANOTHER LOCATION?" + exitMessage());

            IEnumerable<BusRoute> FindBus(string location) =>
                Array.FindAll(busRoutes, route => route.Destination.Contains(location)
                    || route.Destination.Contains(location)
                    || route.IsServed(location));

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

                PresentData(messages);

                System.Console.WriteLine("----------------------------------------------------------------");

                Console.ForegroundColor = ConsoleColor.White;
            }

            void PresentData(params object[] messages) => Array.ForEach(messages, message =>
                {
                    if (IsEnumerable(message))
                        foreach(var item in message as IEnumerable<object>)
                            PresentData(item);
                    else
                        System.Console.WriteLine(message);
                });

            string exitMessage() => "(TYPE \"EXIT\" TO QUIT)";

            bool IsEnumerable(object obj) => typeof(Array).IsAssignableFrom(obj?.GetType());
        }
    }
}