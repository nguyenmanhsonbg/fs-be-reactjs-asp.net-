using ReactWithAspNetCore.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReactWithAspNetCore.Repositories.Interfaces
{
    public interface IWeatherForecastRepository
    {
        Task<IEnumerable<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<WeatherForecast> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default);
        Task UpdateAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}