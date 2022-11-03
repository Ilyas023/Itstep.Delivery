using Itstep.Delivery.GlobalDictionary.Api.Dtos;
using Itstep.Delivery.GlobalDictionary.Api.Entities;
using Itstep.Delivery.GlobalDictionary.Api.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itstep.Delivery.GlobalDictionary.Api.Controllers;

[ApiController]
[Route("api/cities")]
public class CitiesController : ControllerBase
{
    private readonly DataContext _dbContext;

    public CitiesController(DataContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    [HttpGet("retrieve-cities-collection")]
    public async Task<IActionResult> GetCitiesCollection()
    {
        var cities = await _dbContext.Cities.ToListAsync();
        return Ok(cities);
    }

    [HttpGet("retrieve-city-by-id/{id}")]
    public async Task<IActionResult> GetCityById(int id)
    {
        var cities = await _dbContext.Cities.FindAsync(id);
        return Ok(cities);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody]CityDto cityDto)
    {
        City city = new City
        {
            Name = cityDto.Name,
            CountryId = cityDto.CountryId
        };
        await _dbContext.Cities.AddAsync(city);
        await _dbContext.SaveChangesAsync();

        return Created("Created", "to Database");
    }
}
