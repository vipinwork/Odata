using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using OData.Models;
using OData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
namespace OData.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class WeatherDataController : ODataController
    {

        private ODataContext2 _context;
        private readonly ILogger<WeatherDataController> _logger;

        public WeatherDataController(ODataContext2 context, ILogger<WeatherDataController> logger)
        {
            _context = context;
            _logger = logger;


            if (_context.WeatherData.Count() == 0)
            {
                foreach (var b in DataSource.GetWeatherData())
                {
                    _context.WeatherData.Add(b);
                }
                _context.SaveChanges();
                
            }
            

        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var results = _context.WeatherData;//.Include(q => q.City).ToList();
            return Ok(results);
        }
        [HttpGet]
        [Route("/odata/WeatherData/HotCities")]
        [EnableQuery]
        public IActionResult HotCities()
        {
            return Ok(_context.WeatherData);
        }

    }
}
