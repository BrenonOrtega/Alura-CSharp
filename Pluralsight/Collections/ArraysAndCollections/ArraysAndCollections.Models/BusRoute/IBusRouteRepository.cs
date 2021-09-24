using System.Collections.Generic;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Models
{
    public interface IBusRouteRepository : IRepository<BusRoute>
    {
        IEnumerable<BusRoute> FindBus(string location);
    }
}