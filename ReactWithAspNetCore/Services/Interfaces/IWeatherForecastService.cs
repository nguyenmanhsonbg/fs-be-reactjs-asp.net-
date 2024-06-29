using ReactWithAspNetCore.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReactWithAspNetCore.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<WeatherForecast> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default);
        Task UpdateAsync(int id, WeatherForecast weatherForecast, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}