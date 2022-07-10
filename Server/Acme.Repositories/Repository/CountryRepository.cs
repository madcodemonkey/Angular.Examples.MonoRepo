using Acme.Models;

namespace Acme.Repositories;

public class CountryRepository : RepositoryPrimaryKeyBase<Country, int>, ICountryRepository
{
    /// <summary>Constructor</summary>
    public CountryRepository(AcmeContext context) : base(context)
    {
    }
}