using CleanArch.Domain.Entities.Infrastructure;


namespace CleanArch.Infrastructure.Services
{
	public interface IWeatherService
	{
		Task<WeatherInfo> GetWeatherAsync(float lat, float lon);
	}
}
