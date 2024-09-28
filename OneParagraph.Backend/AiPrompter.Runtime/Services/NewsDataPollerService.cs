using AiPrompter.Runtime.Database;
using AiPrompter.Runtime.Models;
using AiPrompter.Runtime.Services.Interfaces;
using OneParagraph.Shared.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services;

public class NewsDataPollerService : INewsDataPollerService
{
    private readonly AppSettings _appSettings;
    private readonly DataContext _dataContext;

    public NewsDataPollerService(AppSettings appSettings, DataContext dataContext)
    {
        _appSettings = appSettings;
        _dataContext = dataContext;
    }

    public async Task<List<MarketauxGetNewsByCategoryResponse>> GetCategoryNewsAsync()
    {
        List<MarketauxGetNewsByCategoryResponse> categoryResponses = new();

        foreach (var item in Enum.GetNames(typeof(Industries)))
        {
            categoryResponses.Add(await GetSingleCategoryNews(Enum.Parse<Industries>(item), "desc"));
            categoryResponses.Add(await GetSingleCategoryNews(Enum.Parse<Industries>(item), "asc"));
        }

        return categoryResponses;
    }

    private async Task<MarketauxGetNewsByCategoryResponse> GetSingleCategoryNews(Industries industry, string order)
    {
        if (order is not "desc" or "asc")
            throw new Exception("Unsupported order type");

        var client = new RestClient(_appSettings.MarketauxApiBaseUrl);

        var request = new RestRequest();

        request.AddQueryParameter("api_token", _appSettings.MarketauxApiKey);
        request.AddQueryParameter("industries", industry.ToString());
        request.AddQueryParameter("filter_entities", "true");
        request.AddQueryParameter("published_after", DateTime.Now.AddHours(-6).ToString("yyyy-MM-ddTHH:mm"));
        request.AddQueryParameter("sort", "entity_sentiment_score");
        request.AddQueryParameter("sort_order", order);
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

        MarketauxGetNewsByCategoryResponse content = JsonSerializer.Deserialize<MarketauxGetNewsByCategoryResponse>(stringResult);

        return content;
    }
}
