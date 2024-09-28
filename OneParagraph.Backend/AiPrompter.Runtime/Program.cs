using AiPrompter.Runtime.Services;
using AiPrompter.Runtime.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AiPrompter.Runtime.Program))]
namespace AiPrompter.Runtime;

internal class Program : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<INewsDataPollerService, NewsDataPollerService>();
    }
}
