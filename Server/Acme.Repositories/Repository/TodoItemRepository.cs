using Acme.Models;

namespace Acme.Repositories
{
    public class TodoItemRepository : RepositoryPrimaryKeyBase<TodoItem, Guid>, ITodoItemRepository 
    {
        /// <summary>Constructor</summary>
        public TodoItemRepository(AcmeContext context) : base(context)
        {
        }
    }
}
