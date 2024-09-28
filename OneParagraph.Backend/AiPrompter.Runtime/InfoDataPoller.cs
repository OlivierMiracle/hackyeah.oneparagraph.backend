using AiPrompter.Runtime.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AiPrompter.Runtime;

public class InfoDataPoller(
    INewsDataPollerService newsDataPollerService)
{
    [FunctionName(nameof(InfoDataPoller))]
    public async Task Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest request,
        ILogger log)
    {
        log.LogInformation("BÓBR");
        await newsDataPollerService.GetNewsDataAsync();
    }
}
