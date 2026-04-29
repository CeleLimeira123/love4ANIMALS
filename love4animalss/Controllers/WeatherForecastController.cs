using Microsoft.AspNetCore.Mvc;

namespace love4animalss.Controllers;

[ApiController]
[Route("v1/weather")] // Cambiamos a v1/weather para mantener la consistencia
[Tags(" Utilidades: Clima")]
[ApiExplorerSettings(GroupName = "v1")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    /// <summary>
    /// Retorna un pronóstico del clima aleatorio para los próximos 5 días.
    /// </summary>
    /// <remarks>
    /// Este endpoint es de utilidad interna para verificar que el servidor responde correctamente.
    /// </remarks>
    [HttpGet(Name = "GetWeatherForecast")]
    [EndpointSummary("Obtener pronóstico")]
    [ProducesResponseType<IEnumerable<WeatherForecast>>(200)]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}