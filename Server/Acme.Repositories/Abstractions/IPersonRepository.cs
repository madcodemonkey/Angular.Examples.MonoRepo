using Acme.Models;

namespace Acme.Repositories;

public interface IPersonRepository : IRepositoryPrimaryKeyBase<Person, int>
{
}