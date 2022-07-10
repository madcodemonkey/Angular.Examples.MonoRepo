using Acme.Models;
using Acme.Services;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPeopleService _peopleService;

    public PeopleController(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    // GET: api/<PersonController>
    [HttpGet]
    public async Task<IEnumerable<Person>> Get()
    {
        return await _peopleService.GetAllAsync();
    }

    // GET api/<PersonController>/5
    [HttpGet("{id}")]
    public async Task<Person> Get(int id)
    {
        return await _peopleService.GetByIdAsync(id);
    }

    // POST api/<PersonController>
    [HttpPost]
    public void Post([FromBody] Person value)
    {
        _peopleService.AddAsync(value);
    }

    // PUT api/<PersonController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Person value)
    {
        _peopleService.UpdateAsync(value);
    }

    // DELETE api/<PersonController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _peopleService.DeleteAsync(id);
    }
}