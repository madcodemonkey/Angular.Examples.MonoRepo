using Acme.Models;

namespace Acme.Repositories;

public class StateRepository : RepositoryPrimaryKeyBase<State, int>, IStateRepository
{
    /// <summary>Constructor</summary>
    public StateRepository(AcmeContext context) : base(context)
    {
    }
}