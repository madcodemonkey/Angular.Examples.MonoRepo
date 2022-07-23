using Acme.Models;

namespace Acme.Services;

public interface ICountryService
{
    Task<List<Country>> GetAllAsync();
    Task<Country> GetByIdAsync(int id);
    Task<bool> UpdateAsync(Country country);
    Task<Country> AddAsync(Country country);
    Task DeleteAsync(int id);
}

