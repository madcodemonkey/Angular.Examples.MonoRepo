﻿using Acme.Models;

namespace Acme.Services;

public interface IStateService
{
    Task<List<State>> GetAllAsync();
    Task<List<State>> GetByCountryIdAsync(int countryId);
    Task<State> GetByIdAsync(int id);
    Task<bool> UpdateAsync(State state);
    Task<State> AddAsync(State state);
    Task DeleteAsync(int id);
}

