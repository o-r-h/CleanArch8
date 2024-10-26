using CleanArch.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		//private readonly IWeatherService _weatherService;

		//public WeatherForecastController(IWeatherService weatherService)
		//{
		//	_weatherService = weatherService;
		//}

		//[HttpGet]
		//public async Task<IActionResult> Get(float lat, float lon)
		//{
		//	var weatherInfo = await _weatherService.GetWeatherAsync(lat, lon);
		//	return Ok(weatherInfo);
		//}
	}
}
