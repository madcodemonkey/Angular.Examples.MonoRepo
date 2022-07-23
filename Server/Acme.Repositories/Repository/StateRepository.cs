using Acme.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.Repositories;

public class StateRepository : RepositoryPrimaryKeyBase<State, int>, IStateRepository
{
    /// <summary>Constructor</summary>
    public StateRepository(AcmeContext context) : base(context)
    {
    }

    public async Task<List<State>> GetByCountryIdAsync(int countryId)
    {
       return  await Context.States
            .Where(w => w.CountryId == countryId)
            .ToListAsync();
    }
}