using Acme.Models;
using Acme.Repositories;


namespace Acme.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<List<State>> GetAllAsync()
        {
            return await _stateRepository.GetAsync();
        }

        public async Task<List<State>> GetByCountryIdAsync(int countryId)
        {
            return await _stateRepository.GetByCountryIdAsync(countryId);
        }

        public async Task<State> GetByIdAsync(int id)
        {
            return await _stateRepository.GetFirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<bool> UpdateAsync(State state)
        {
            var item = await GetByIdAsync(state.Id);
            if (item == null) return false;

            item.Name = state.Name;
            item.Description = state.Description;

            await _stateRepository.UpdateAsync(item, true);

            return true;
        }

        public async Task<State> AddAsync(State state)
        {
            if (state.Id != 0) throw new ArgumentException("Please don't add existing states!");

            await _stateRepository.AddAsync(state);

            return state;
        }

        public async Task DeleteAsync(int id)
        {
            await _stateRepository.DeleteAsync(id, true);
        }

      
    }
}
