using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactWithAspNetCore.Models;
using ReactWithAspNetCore.Services.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReactWithAspNetCore.Services;

namespace ReactWithAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecastService service, ILogger<WeatherForecastController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetWeatherForecasts(CancellationToken cancellationToken)
        {
            var forecasts = await _service.GetAllAsync(cancellationToken);
            return Ok(forecasts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> GetWeatherForecast(int id, CancellationToken cancellationToken)
        {
            var forecast = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(forecast);
        }

        [HttpPost]
        public async Task<ActionResult<WeatherForecast>> PostWeatherForecast(WeatherForecast weatherForecast, CancellationToken cancellationToken)
        {
            await _service.AddAsync(weatherForecast, cancellationToken);
            return CreatedAtAction(nameof(GetWeatherForecast), new { id = weatherForecast.Id }, weatherForecast);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherForecast(int id, WeatherForecast weatherForecast, CancellationToken cancellationToken)
        {
            if (id != weatherForecast.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            await _service.UpdateAsync(id, weatherForecast, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherForecast(int id, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
