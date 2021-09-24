namespace ArraysAndCollections.Models
{
    public class BusTime
    {
        public BusTime(BusRoute route, string[,] times)
        {
            Route = route;
            Times = times;
        }

        public string[,] Times { get; set; }
        public BusRoute Route { get; set; }
    }
}