using AiPrompter.Runtime.Models;
using AiPrompter.Runtime.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace AiPrompter.Runtime;

public class InfoDataPoller(
    INewsDataPollerService newsDataPollerService)
{
    [FunctionName(nameof(InfoDataPoller))]
    public async Task<Response> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest request)
    {
        var apiResult = await newsDataPollerService.GetCategoryNewsAsync();

        return new Response(true);
    }
}
