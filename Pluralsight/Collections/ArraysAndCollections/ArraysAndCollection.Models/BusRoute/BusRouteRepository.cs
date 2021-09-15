using ArraysAndCollection.Models.Shared;
using PokeApiNet;
using System.Linq;
using System.Threading.Tasks;

namespace ArraysAndCollection.Models
{
    public class BusRouteRepository : Repository<BusRoute>, IRepository<BusRoute>
    {
        private static PokeApiClient pokeClient = new PokeApiClient();

        public BusRouteRepository()
        {
            var task = Task.Run(async () => Data = await Load());
            task.Wait();
        }
        
        public async Task<BusRoute[]> Load()
        {
            var kanto = await pokeClient.GetResourceAsync<Region>(1);
            var indexedLocations = kanto.Locations.Select((location, index) => new { location.Name, index });
            var reversedLocations = indexedLocations.Reverse();

            var projected = indexedLocations.Zip(reversedLocations,
                (indexedLocation, reversedLocation) =>
                    new { indexedLocation.index, Origin = indexedLocation.Name, Destination = reversedLocation.Name })
                .Select(x => new BusRoute(x.Origin, x.Origin, x.Destination, x.index));

            return projected.ToArray();
        }
    }
}