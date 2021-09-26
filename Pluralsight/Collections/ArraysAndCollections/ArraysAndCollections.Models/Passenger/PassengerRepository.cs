using System;
using System.Collections.Generic;
using System.Linq;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Models
{
    public class PassengerRepository : IRepository<Passenger>
    {
        private ICollection<Passenger> Passengers { get; set; } = new HashSet<Passenger>(Generate(Bus.MAXIMUM_CAPACITY));

        private static IEnumerable<Passenger> Generate(int quantity)
        {
            for (int i = 0; i <= quantity; i++)
                yield return new Passenger($"Passenger {i}", $"{ (i % 2 == 0 ? "viridian" : "celadon") }");
        }

        public bool Add(Passenger entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Passenger> Get(Func<Passenger, bool> filter = null)
        {
            filter ??= _ => true;
            return Passengers.Where(filter);
        }

        public Passenger GetSingle(Func<Passenger, bool> filter = null)
        {
            return Get(filter).Single();
        }

        public bool Remove(Func<Passenger, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Passenger entity, Func<Passenger, bool> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}