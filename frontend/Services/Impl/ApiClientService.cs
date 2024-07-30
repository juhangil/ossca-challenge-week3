using YoutubeSummarizer.Model;

namespace YoutubeSummarizer.Frontend.Services.Impl;

public class ApiClientService(HttpClient http) : IApiClientService
{
    private readonly HttpClient _http = http
        ?? throw new ArgumentNullException(nameof(http), Errors.NULL_ERROR);

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
    {
        using (var response = await _http.GetAsync("WeatherForecast").ConfigureAwait(false))
        {
            var forecast = await response.Content
                .ReadFromJsonAsync<IEnumerable<WeatherForecast>>()
                .ConfigureAwait(false);

            return forecast ?? Enumerable.Empty<WeatherForecast>();
        }
    }
}