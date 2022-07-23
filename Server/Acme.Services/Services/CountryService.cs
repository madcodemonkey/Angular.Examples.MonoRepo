using Acme.Models;
using Acme.Repositories;


namespace Acme.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _countryRepository.GetAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _countryRepository.GetFirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<bool> UpdateAsync(Country country)
        {
            var item = await GetByIdAsync(country.Id);
            if (item == null) return false;

            item.Name = country.Name; 

            await _countryRepository.UpdateAsync(item, true);

            return true;
        }

        public async Task<Country> AddAsync(Country country)
        {
            if (country.Id != 0) throw new ArgumentException("Please don't add existing country!");

            await _countryRepository.AddAsync(country);

            return country;
        }

        public async Task DeleteAsync(int id)
        {
            await _countryRepository.DeleteAsync(id, true);
        }
    }
}
