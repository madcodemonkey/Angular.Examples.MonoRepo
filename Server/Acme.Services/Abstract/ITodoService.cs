using Acme.Models;

namespace Acme.Services;

public interface ITodoService
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(Guid id);
    Task<TodoItem?> UpdateAsync(TodoItem todo);
    Task<TodoItem> AddAsync(TodoItem todo);
    Task DeleteAsync(TodoItem todo);
}