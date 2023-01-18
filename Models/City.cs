using System.ComponentModel.DataAnnotations;

namespace OData.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; } 
        public string cityname { get; set; }
        
        public string state { get; set; }   

        public City(int Id,string cityname, string state)
        {
            this.Id = Id;
            this.cityname = cityname;
            this.state = state;
        }
        public City()
        {

        }
    }
}
