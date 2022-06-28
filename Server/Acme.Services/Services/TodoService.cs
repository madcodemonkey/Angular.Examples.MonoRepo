using Acme.Models;
using Acme.Repositories;

namespace Acme.Services;

public class TodoService : ITodoService
{
    private readonly ITodoItemRepository _todoItemRepository;

    /// <summary>Constructor</summary>
    public TodoService(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _todoItemRepository.GetAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(Guid id)
    {
        return await _todoItemRepository.GetAsync(id);
    }

    public async Task<TodoItem?> UpdateAsync(TodoItem todo)
    {
        var existingTodo =  await GetByIdAsync(todo.Id);
        if (existingTodo == null) return null;

        existingTodo.Title = todo.Title;
        existingTodo.Description = todo.Description;
        existingTodo.Status = todo.Status;
        await _todoItemRepository.UpdateAsync(existingTodo);

        return existingTodo;
    }

    public async Task<TodoItem> AddAsync(TodoItem todo)
    {
        if (todo.Id != Guid.Empty) throw new ArgumentException("Please don't add existing todo!");
        todo.Id = Guid.NewGuid();

        return await _todoItemRepository.AddAsync(todo);
    }

    public async Task DeleteAsync(TodoItem todo)
    {
        await _todoItemRepository.DeleteAsync(todo);
    }

}