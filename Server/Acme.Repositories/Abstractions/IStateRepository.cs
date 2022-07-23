using Acme.Models;

namespace Acme.Repositories;

public interface IStateRepository : IRepositoryPrimaryKeyBase<State, int>
{
    Task<List<State>> GetByCountryIdAsync(int countryId);
}