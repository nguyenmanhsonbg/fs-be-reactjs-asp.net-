using ReactWithAspNetCore.Models;
using ReactWithAspNetCore.Repositories.Interfaces;
using ReactWithAspNetCore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReactWithAspNetCore.Repositories;

namespace ReactWithAspNetCore.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastService(IWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }

        public async Task<WeatherForecast> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public async Task AddAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(weatherForecast, cancellationToken);
        }

        public async Task UpdateAsync(int id, WeatherForecast weatherForecast, CancellationToken cancellationToken = default)
        {
            if (id != weatherForecast.Id)
            {
                throw new BadHttpRequestException("ID mismatch");
            }
            await _repository.UpdateAsync(weatherForecast, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }
    }
}