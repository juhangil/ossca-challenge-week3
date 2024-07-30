using YoutubeSummarizer.Model;

namespace YoutubeSummarizer.Frontend.Client;

internal interface IApiClient
{
    public Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync();
}