using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OData.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ODataContext>(opt => opt.UseInMemoryDatabase("Cars"));
builder.Services.AddDbContext<ODataContext2>(opt => opt.UseInMemoryDatabase("WeatherData"));
builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata",GetEdmModel()).Filter().Select().Expand());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    
    builder.EntitySet<Weather>("WeatherData");
    //builder.EntitySet<City>("City");
    builder.EntityType<Weather>().HasKey(q => q.Id);
    builder.EntityType<City>().HasKey(q => q.Id);
    //builder.EntityType<Weather>().Property(q => q.City).IsNotExpandable();
    //builder.EntityType<Weather>().Expand(SelectExpandType.Automatic, nameof(Weather.City));
    builder.EntityType<Weather>().HasRequired(q => q.City, (Forecast, City) => Forecast.CityId == City.Id);
    builder.EntityType<Weather>().Property(q => q.TemperatureC).IsNotFilterable();
    return builder.GetEdmModel();
}