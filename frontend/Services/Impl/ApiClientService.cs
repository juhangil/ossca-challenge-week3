﻿using YoutubeSummarizer.Model;

namespace YoutubeSummarizer.Frontend.Services.Impl;

public class ApiClientService(HttpClient http) : IApiClientService
{
    private readonly HttpClient _http = http
        ?? throw new ArgumentNullException(nameof(http), Errors.NULL_ERROR);

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
    {
        using (var response = await _http.GetAsync("weatherforecast").ConfigureAwait(false))
        {
            var forecast = await response.Content
                .ReadFromJsonAsync<IEnumerable<WeatherForecast>>()
                .ConfigureAwait(false);

            return forecast ?? Enumerable.Empty<WeatherForecast>();
        }
    }

    public async Task<string> SummarizeAsync(string videoUrl, string videoLanguageCode, string summaryLanguageCode)
    {
        var summary = string.Empty;
        var req = new SummaryRequest
        {
            VideoURL = videoUrl,
            VideoLanguageCode = videoLanguageCode,
            SummaryLanguageCode = summaryLanguageCode
        };
        using(var response = await _http.PostAsJsonAsync("summarize", req).ConfigureAwait(false))
        {
            summary = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
        return summary;
    }
}