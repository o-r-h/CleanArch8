

using CleanArch.Domain.Entities.Infrastructure;


namespace CleanArch.Infrastructure.Services
{
	public class WeatherService : IWeatherService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey;

		public WeatherService(HttpClient httpClient, string apiKey)
		{
			_httpClient = httpClient;
			_apiKey = apiKey;
		}

		public async Task<WeatherInfo> GetWeatherAsync(float lat, float lon)
		{
			//var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_apiKey}");
			//response.EnsureSuccessStatusCode();

			//var content = await response.Content.ReadAsStringAsync();
			//var json = JObject.Parse(content);

			//var weatherInfo = new WeatherInfo
			//{
			//	Description = json["weather"][0]["description"].ToString(),
			//	Temperature = float.Parse(json["main"]["temp"].ToString())

			//};
			var weatherInfo = new WeatherInfo();
			return weatherInfo;
		}
	}
}
