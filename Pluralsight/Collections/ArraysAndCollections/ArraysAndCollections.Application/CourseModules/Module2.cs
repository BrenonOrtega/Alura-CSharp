using ArraysAndCollections.Models;
using ArraysAndCollections.Models.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static ArraysAndCollections.Application.Helper;
namespace ArraysAndCollections.Application.CourseModules
{
    ///<Summary>
    ///Module Two is talks about searching data and getting data from Lists.
    ///</Summary>
    public class Module2 : IExercise
    {
        private readonly IBusRouteRepository _repo;

        public Module2() => _repo = new BusRouteRepository();

        public void Run(string[] args)
        {
            var routes = _repo.Get();
            if (Array.Exists(args, arg => "-i".Equals(arg) || "--interactive".Equals(arg)))
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
                var result = _repo.FindBus(desiredLocation);
                var color = result.Equals(BusRoute.Null) ? ConsoleColor.Red : ConsoleColor.Green;
                var routes = result.Select(route => route.ToString()).ToArray();

                PrintWithBars(color, "HERE'S WHAT WE FOUND FOR YOUR SEARCH:", routes);
            }

            void AskIfWannaSearchAnotherRoute() =>
                PrintWithSpacesAndBars(ConsoleColor.Yellow, "WOULD YOU LIKE TO SEE ANOTHER LOCATION?" + exitMessage());

            void ChottoMatte(TimeSpan waitTime) => Thread.Sleep(waitTime);

            string exitMessage() => "(TYPE \"EXIT\" TO QUIT)";
        }

    }
}