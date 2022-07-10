using Acme.Models;

namespace Acme.Repositories;

public class PersonRepository : RepositoryPrimaryKeyBase<Person, int>, IPersonRepository
{
    /// <summary>Constructor</summary>
    public PersonRepository(AcmeContext context) : base(context)
    {
    }
}