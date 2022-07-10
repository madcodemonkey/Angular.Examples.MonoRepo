using Acme.Models;
using Acme.Services;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateService _stateService;

    public StateController(IStateService stateService)
    {
        _stateService = stateService;
    }

    // GET: api/<StateController>
    [HttpGet]
    public async Task<IEnumerable<State>> Get()
    {
        return await  _stateService.GetAllAsync();
    }

    // GET api/<StateController>/5
    [HttpGet("{id}")]
    public async Task<State> Get(int id)
    {
        return await _stateService.GetByIdAsync(id);
    }

    // POST api/<StateController>
    [HttpPost]
    public async Task Post([FromBody] State item)
    {
        await  _stateService.AddAsync(item);
    }

    // PUT api/<StateController>/5
    [HttpPut("{id}")]
    public async Task Put(int id, [FromBody] State item)
    {
       await _stateService.UpdateAsync(item);
    }

    // DELETE api/<StateController>/5
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _stateService.DeleteAsync(id);
    }
}