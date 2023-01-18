using System.ComponentModel.DataAnnotations;
using Microsoft.OData.ModelBuilder;

namespace OData.Models
{
    [Filter("TemperatureC",Disabled = true)]
    [Expand("City", ExpandType =SelectExpandType.Allowed)]
    public class Weather
    {
        [Key]
        public int Id { get; set; }
        
        public int TemperatureC { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }

        public  City City { get; set; }
        public int  CityId { get; set; }    

        public Weather(int Id,DateTime date, int temperatureC, string summary, City city)
        {
            this.Id = Id;
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
            City = city;
            CityId = city.Id;
        }
        public Weather()
        {

        }
    }
}
