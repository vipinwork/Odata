using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace OData.Models
{
    public class ODataContext2: DbContext
    {
        public ODataContext2(DbContextOptions options) : base(options)
        {
        }
      
        public DbSet<Weather> WeatherData { get; set; }
        public DbSet<City> CityData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>(b => { b.HasOne(q => q.City).WithMany().HasForeignKey(x => x.Id).IsRequired(); });
        }
    }
}