using Acme.Models;

namespace Acme.Repositories;

public interface ITodoItemRepository : IRepositoryPrimaryKeyBase<TodoItem, Guid>
{
}