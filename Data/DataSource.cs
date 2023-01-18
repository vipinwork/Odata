using OData.Models;

namespace OData.Data
{
    public static class DataSource
    {
        //private static List<Car> _cars { get; set; }
        private static List<Weather> weather { get; set; }

        public static IEnumerable<Weather> GetWeatherData()
        {
            if (weather!= null)
            {
                return weather;
            }
            City hyd = new City(4,"Hyderabad", "telangana");
            City mum = new City(5,"Mumbai", "Maharashtra");
            weather = new List<Weather>();
            DateTime a= DateTime.Now;
            weather.Add(new Weather(4,a, 37, "Moderately cold dry weather",hyd));
            weather.Add(new Weather(5, a, 89, "Hot weather",mum));
            DateTime b= DateTime.Now;
           

            return weather;
        }
        /*public static IEnumerable<Car> GetCars()
        {
            if (_cars != null)
            {
                return _cars;
            }

            _cars = new List<Car>();

            _cars.Add(new Car(1, "Tesla", 59.99m, "Model 3"));
            _cars.Add(new Car(2, "BMW", 49.99m, "3 Series"));

            return _cars;
        }*/
    }
}