using Acme.Models;

namespace Acme.Services;

public interface IPeopleService
{
    Task<List<Person>> GetAllAsync();
    Task<Person> GetByIdAsync(int id);
    Task<bool> UpdateAsync(Person person);
    Task AddAsync(Person person);
    Task DeleteAsync(int id);
}