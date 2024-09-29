using System;
using AiPrompter.Runtime.Models;
using AiPrompter.Runtime.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using OneParagraph.Shared.Content;
using OneParagraph.Shared.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AiPrompter.Runtime.Database;

namespace AiPrompter.Runtime;

public class InfoDataPoller(
    INewsDataPollerService newsDataPollerService,
    IAiServiceContext aiServiceContext,
    DataContext context)
{
    [FunctionName(nameof(InfoDataPoller))]
    public async Task<Response> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequest request)
    {
        //var apiResult = await newsDataPollerService.GetCategoryNewsAsync();
        //var result = await aiServiceContext.PromptAi(apiResult);

        var apiResultStock = await newsDataPollerService.GetStockNewsAsync();
        var resultStock = await aiServiceContext.PromptAiFormStock(apiResultStock);

        //await CreateIndustryParagraphs(apiResult, result);
        await CreateStockParagraphs(resultStock);

        return new Response(true);
    }

    private async Task CreateIndustryParagraphs(Dictionary<Industries, List<MarketauxGetNewsByCategoryResponse>> apiResult, List<(Industries, string)> result)
    {
        var paragraphs = new List<IndustryParagraph>();

        foreach (var news in result)
        {
            List<Stock> stocks = [];

            paragraphs.Add(new IndustryParagraph()
            {
                Id = Guid.NewGuid(),
                Industry = news.Item1,
                Paragraph = news.Item2,
                Stocks = apiResult[news.Item1]
                    .SelectMany(r => r.Data)
                    .SelectMany(d => d.Entities)
                    .Select(e => e.Symbol)
                    .ToHashSet()
                    .ToList(),
                DateTime = DateTime.Now,
                SourceUrls = GetSourceUrls(apiResult[news.Item1]),
                SourceNames = GetSourceNames(apiResult[news.Item1])
            });
        }

        context.IndustryParagraphs.AddRange(paragraphs);
        
        context.SaveChanges();
    }

    private static List<string> GetSourceUrls(List<MarketauxGetNewsByCategoryResponse> data)
    {
        var result = new HashSet<string>();

        foreach (var item in data)
        {
            foreach (var news in item.Data)
            {
                result.Add(news.Url);
            }
        }

        return result.ToList();
    }

    private static List<string> GetSourceNames(List<MarketauxGetNewsByCategoryResponse> data)
    {
        var result = new HashSet<string>();

        foreach (var item in data)
        {
            foreach (var news in item.Data)
            {
                result.Add(news.Source);
            }
        }

        return result.ToList();
    }

    private async Task CreateStockParagraphs(List<(Stock, string)> stocks)
    {
        var stocksParagraphs = new List<StockParagraph>();

        foreach (var stock in stocks)
        {
            stocksParagraphs.Add(new StockParagraph()
            {
                Id = Guid.NewGuid(),
                Stock = stock.Item1,
                Paragraph = stock.Item2
            });

            context.StockParagraphs.AddRange(stocksParagraphs);

            await context.SaveChangesAsync();
        }
    }
}