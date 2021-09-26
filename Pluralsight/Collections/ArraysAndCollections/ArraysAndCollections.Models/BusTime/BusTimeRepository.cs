using System;
using System.Collections.Generic;
using System.Linq;
using ArraysAndCollections.Models.Shared;

namespace ArraysAndCollections.Models
{
    public class BusTimeRepository : IRepository<BusTime>
    {
        static string[,] times =
        {
            {"01:00", "02:00", "03:00", "04:00"},
            {"11:00", "12:00", "13:00", "14:00"},
            {"21:00", "22:00", "23:00", "00:00"},
        };

        private ICollection<BusTime> _busTimes = new List<BusTime>()
        {
            new(new BusRoute("viridian", "viridian", "celadon", 5), times),
            new(new BusRoute("celadon", "celadon", "lavender", 7), times),
            new(new BusRoute("lavender", "lavender", "unova", 10), times),
            new(new BusRoute("unova", "unova", "celadon", 15), times),
            new(new BusRoute("great four league", "great four league", "pallet", 175), times),
        };

        public bool Add(BusTime entity)
        {
            if (entity is null)
                return false;

            _busTimes.Add(entity);
            return true;
        }

        public IEnumerable<BusTime> Get(Func<BusTime, bool> filter = null)
        {
            filter ??= _ => true;
            return _busTimes.Where(filter);
        }

        public BusTime GetSingle(Func<BusTime, bool> filter = null)
        {
            return Get().SingleOrDefault();
        }

        public bool Remove(Func<BusTime, bool> filter = null)
        {
            try{
                _busTimes =  _busTimes.Except(_busTimes.Where(filter)).ToList();
                return true;
            }
            catch
            {
                System.Console.WriteLine("error removing elements");
                return false;
            }
        }

        public bool Update(BusTime entity, Func<BusTime, bool> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}