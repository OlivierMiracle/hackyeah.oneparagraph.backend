using AiPrompter.Runtime.Models;
using AiPrompter.Runtime.Services.Interfaces;
using OneParagraph.Shared.Enums;
using OneParagraph.Shared.Extensions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services;

public class NewsDataPollerService(AppSettings appSettings) : INewsDataPollerService
{
    public async Task<Dictionary<Industries, List<MarketauxGetNewsByCategoryResponse>>> GetCategoryNewsAsync()
    {
        Dictionary<Industries, List<MarketauxGetNewsByCategoryResponse>> categoryResponses = new();

        foreach (var item in Enum.GetNames(typeof(Industries)))
        {
            var enumVal = Enum.Parse<Industries>(item);

            var newsPositive = await GetSingleCategoryNews(enumVal, "desc");
            var newsNegative = await GetSingleCategoryNews(enumVal, "asc");

            categoryResponses[enumVal] = [newsPositive, newsNegative];
        }

        return categoryResponses;
    }

    private async Task<MarketauxGetNewsByCategoryResponse> GetSingleCategoryNews(Industries industry, string order)
    {
        var client = new RestClient(appSettings.MarketauxApiBaseUrl);

        var request = new RestRequest();

        request.AddQueryParameter("api_token", appSettings.MarketauxApiKey);
        request.AddQueryParameter("industries", industry.GetEnumDescription());
        request.AddQueryParameter("filter_entities", "true");
        request.AddQueryParameter("published_after", DateTime.Now.AddDays(-1).ToString("yyyy-MM-ddTHH:mm"));
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
