using Todo.Repositories;

namespace Acme.Repositories;

internal class SeedAcmeDatabase
{
    public static async Task SeedDataAsync(AcmeContext context)
    {
        await SeedAcmeTableTodoItem.SeedDataAsync(context);
        await SeedAcmeTablePerson.SeedDataAsync(context);
    }
}