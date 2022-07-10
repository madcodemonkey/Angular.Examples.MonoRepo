using Acme.Models;
using Acme.Repositories;

namespace Acme.Services;

public class PeopleService : IPeopleService
{
    private readonly IPersonRepository _personRepository;

    public PeopleService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<List<Person>> GetAllAsync()
    {
        return await _personRepository.GetAsync();
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        return await _personRepository.GetFirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<bool> UpdateAsync(Person person)
    {
        var existingPerson = await GetByIdAsync(person.Id);
        if (existingPerson == null) return false;

        existingPerson.FirstName = person.FirstName;
        existingPerson.LastName = person.LastName;
        existingPerson.Email = person.Email;
        existingPerson.DateOfBirth = person.DateOfBirth;
        existingPerson.AddressLine1 = person.AddressLine1;
        existingPerson.AddressLine2 = person.AddressLine2;
        existingPerson.StateId = person.StateId;
        existingPerson.PostalCode = person.PostalCode;

        await _personRepository.UpdateAsync(existingPerson);

        return true;
    }

    public async Task AddAsync(Person person)
    {
        if (person.Id != 0) throw new ArgumentException("Please don't add existing users!");

        await _personRepository.AddAsync(person, true);
    }

    public async Task DeleteAsync(int id)
    {
        await _personRepository.DeleteAsync(id);
    }
}