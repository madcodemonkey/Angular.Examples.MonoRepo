using Acme.Models;
using Acme.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Acme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _todoService.GetAllAsync();
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public async Task<TodoItem?> Get(Guid id)
        {
            return await _todoService.GetByIdAsync(id);
        }

        // POST api/<TodoController>
        [HttpPost]
        public async Task<TodoItem> Post([FromBody] TodoItem item)
        {
           return await  _todoService.AddAsync(item);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TodoItem item)
        {
            item.Id = id;
            var result = await _todoService.UpdateAsync(item);
            if (result == null)
                return NotFound("Unable to find the todo!");

            return Ok(result);
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var todo = await _todoService.GetByIdAsync(id);
            if (todo != null)
            {
                await _todoService.DeleteAsync(todo);
                return Ok(todo);
            }

            return NotFound();
        }
    }
}
