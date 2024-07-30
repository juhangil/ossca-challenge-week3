using YoutubeSummarizer.Model;

namespace YoutubeSummarizer.Frontend.Services;

internal interface IApiClientService
{
    public Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync();
}