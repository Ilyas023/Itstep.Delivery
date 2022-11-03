using Itstep.Delivery.GlobalDictionary.Api.Dtos;
using Itstep.Delivery.GlobalDictionary.Api.Entities;
using Itstep.Delivery.GlobalDictionary.Api.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Itstep.Delivery.GlobalDictionary.Api.Controllers;

[ApiController]
[Route("api/countries")]
public class CountriesController : ControllerBase
{
    private readonly DataContext _dbContext;
    public CountriesController(DataContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    [HttpGet("retrieve-countries-collection")]
    public async Task<IActionResult> GetCountriesCollection()
    {
        var countries = await _dbContext.Countries
            .Include(x => x.Cities)
            .ToListAsync();
        return Ok(countries);
    }

    [HttpGet("retrieve-country-by-id/{id}")]
    public async Task<IActionResult> GetCountryById(int id)
    {
        var countries = await _dbContext.Countries.FindAsync(id);
        return Ok(countries);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CountryDto countryDto)
    {
        Country country = new Country
        {
            Name = countryDto.Name,
        };

        if (_dbContext.Countries.Any(x => x.Name == countryDto.Name))
        {
            return Conflict(countryDto.Name);
        }
        await _dbContext.Countries.AddAsync(country);
        await _dbContext.SaveChangesAsync();

        return Created("Created", "to Database");
    }
}
