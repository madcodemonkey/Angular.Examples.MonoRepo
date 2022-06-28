using Acme.Models;
using Acme.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Todo.Repositories;

internal class SeedAcmeTableTodoItem
{

    public static async Task SeedDataAsync(AcmeContext context)
    {
        // If there is any data, return
        if (await context.Todos.AnyAsync()) return;

        context.Todos.Add(new TodoItem
        {
            Description = "Get some milk",
            Title = "Grocery: Milk",
            Status = "open"
        });

        context.Todos.Add(new TodoItem
        {
            Description = "Bread",
            Title = "Bread",
            Status = "open"
        });

        context.Todos.Add(new TodoItem
        {
            Description = "Sugar",
            Title = "Sugar",
            Status = "open"
        });

        await context.SaveChangesAsync();
    }
}