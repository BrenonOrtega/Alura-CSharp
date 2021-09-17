using ArraysAndCollection.Models.Shared;
using PokeApiNet;
using System.Linq;
using System.Threading.Tasks;

namespace ArraysAndCollection.Models
{
    public class BusRouteRepository : Repository<BusRoute>, IRepository<BusRoute>
    {
        public BusRouteRepository()
        {
            using var pokeClient = new PokeApiClient();
            var task = Task.Run(async () => Data = await Load(pokeClient));
            task.Wait();
        }
        
        public async Task<BusRoute[]> Load(PokeApiClient pokeClient)
        {
            var kanto = await pokeClient.GetResourceAsync<Region>(1);
            var indexedLocations = kanto.Locations.Select((location, index) => new { location.Name, index });
            var reversedLocations = indexedLocations.Reverse();

            var projected = indexedLocations.Zip(reversedLocations,
                (indexedLocation, reversedLocation) =>
                    new { indexedLocation.index, Origin = indexedLocation.Name, Destination = reversedLocation.Name })
                .Select(x => new BusRoute(x.Origin, x.Origin, x.Destination, x.index))
                .ToArray();

            for (var index = 0; index < projected.Length; index++)
            {
                var lastItemIndex =  projected.Length - 1;
               
                if (index < lastItemIndex)
                    AddSubSequentItem();

                if (index > 0 )
                    AddPreviousItem();

                void AddSubSequentItem() => projected[index].AddServedRoute(projected[index + 1]);

                void AddPreviousItem() => projected[index].AddServedRoute(projected[index - 1 ]);
            }

            return projected;
        }
    }
}