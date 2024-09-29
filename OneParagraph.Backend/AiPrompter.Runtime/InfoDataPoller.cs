using AiPrompter.Runtime.Models;
using AiPrompter.Runtime.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using OneParagraph.Shared.Content;
using OneParagraph.Shared.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AiPrompter.Runtime;

public class InfoDataPoller(
    INewsDataPollerService newsDataPollerService,
    IAiServiceContext aiServiceContext)
{
    [FunctionName(nameof(InfoDataPoller))]
    public async Task<Response> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest request)
    {
        var apiResult = await newsDataPollerService.GetCategoryNewsAsync();
        var result = await aiServiceContext.PromptAi(apiResult);

        var paragraphs = CreateIndustryParagraph(apiResult, result);

        return new Response(true);
    }

    private static List<IndustryParagraph> CreateIndustryParagraph(Dictionary<Industries, List<MarketauxGetNewsByCategoryResponse>> apiResult, List<(Industries, string)> result)
    {
        var paragraphs = new List<IndustryParagraph>();

        //foreach (var news in result) 
        //{
        //    paragraphs.Add(new IndustryParagraph()
        //    {
        //        Id = Guid.NewGuid(),
        //        Industry = news.Item1,
        //        Paragraph = news.Item2,
        //        Stock = new()
        //        {
        //            Id = Guid.NewGuid(),
        //            Symbol = "",
        //            Name = ""
        //        },
        //        DateTime = DateTime.Now,
        //        SourceUrls = GetSources(apiResult[news.Item1])
        //    });
        //}

        return paragraphs;
    }

    //private static string GetStockSymbol(List<MarketauxGetNewsByCategoryResponse> apiResult) 
    //{
    //    foreach (var item in apiResult)
    //    {
    //        foreach (var news in item.Data)
    //        {
    //            return news.
    //        }
    //    }   
    //}

    //private static string GetStockName(List<MarketauxGetNewsByCategoryResponse> apiResult)
    //{

    //}

    private static List<(string, string)> GetSources(List<MarketauxGetNewsByCategoryResponse> data)
    {
        var result = new List<(string, string)>();

        foreach (var item in data)
        {
            foreach (var news in item.Data)
            {
                result.Add((news.Source, news.Url));
            }
        }

        return result;
    }
}
