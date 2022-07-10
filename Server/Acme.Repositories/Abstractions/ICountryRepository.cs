using Acme.Models;

namespace Acme.Repositories;

public interface ICountryRepository : IRepositoryPrimaryKeyBase<Country, int>
{
}