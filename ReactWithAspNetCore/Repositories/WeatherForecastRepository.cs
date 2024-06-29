using Microsoft.EntityFrameworkCore;
using ReactWithAspNetCore.Data;
using ReactWithAspNetCore.Models;
using ReactWithAspNetCore.Repositories.Interfaces;
using System.Threading;

namespace ReactWithAspNetCore.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApplicationDbContext _context;

        public WeatherForecastRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.WeatherForecasts.ToListAsync(cancellationToken);
        }

        public async Task<WeatherForecast> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var weatherForecast = await _context.WeatherForecasts.FindAsync(new object[] { id }, cancellationToken);
            return weatherForecast ?? throw new KeyNotFoundException($"Weather forecast with ID {id} not found.");
        }

        public async Task AddAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default)
        {
            await _context.WeatherForecasts.AddAsync(weatherForecast, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken = default)
        {
            _context.Entry(weatherForecast).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var weatherForecast = new WeatherForecast { Id = id };
            _context.WeatherForecasts.Attach(weatherForecast);
            _context.WeatherForecasts.Remove(weatherForecast);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
