using Acme.Models;
using Acme.Services;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    // GET: api/<CountryController>
    [HttpGet]
    public async Task<IEnumerable<Country>> Get()
    {
        return await  _countryService.GetAllAsync();
    }

    // GET api/<CountryController>/5
    [HttpGet("{id}")]
    public async Task<Country> Get(int id)
    {
        return await _countryService.GetByIdAsync(id);
    }

    // POST api/<CountryController>
    [HttpPost]
    public async Task Post([FromBody] Country item)
    {
        await  _countryService.AddAsync(item);
    }

    // PUT api/<CountryController>/5
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] Country item)
    {
       await _countryService.UpdateAsync(item);
    }

    // DELETE api/<CountryController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _countryService.DeleteAsync(id);
    }
}