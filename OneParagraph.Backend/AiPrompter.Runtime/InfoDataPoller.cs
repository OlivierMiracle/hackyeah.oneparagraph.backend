using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiPrompter.Runtime;

public class InfoDataPoller
{
    [FunctionName(nameof(InfoDataPoller))]
    public void Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest request,
        ILogger log)
    {
        log.LogInformation("BÓBR");
    }
}
