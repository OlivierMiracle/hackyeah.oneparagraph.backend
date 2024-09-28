using AiPrompter.Runtime.Models;
using AiPrompter.Runtime.Services.Interfaces;
using RestSharp;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services;

public class NewsDataPollerService : INewsDataPollerService
{
    private readonly AppSettings _appSettings;

    public NewsDataPollerService(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public async Task GetCategoryNewsAsync(string category)
    {
        if (string.IsNullOrEmpty(category))
            return;

        var client = new RestClient(_appSettings.MarketauxApiBaseUrl);

        var request = new RestRequest();

        request.AddQueryParameter("api_token", _appSettings.MarketauxApiKey);
        request.AddQueryParameter("industries", "Technology");
        request.AddQueryParameter("filter_entities", "true");
        request.AddQueryParameter("published_after", DateTime.Now.AddHours(-6).ToString("yyyy-MM-ddTHH:mm"));
        request.AddQueryParameter("sort", "entity_sentiment_score");
        request.AddQueryParameter("sort_order", "desc");
        request.AddQueryParameter("language", "en");

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessStatusCode is false)
        {
            throw new HttpRequestException("Getting news by Category failed!");
        }

        if (string.IsNullOrEmpty(response.Content))
        {
            throw new HttpRequestException("Response is null or empty");
        }

        var stringResult = response.Content;

        MarketauxGetNewsByCategoryResponse content2 = JsonSerializer.Deserialize<MarketauxGetNewsByCategoryResponse>(stringResult);
    }
}
