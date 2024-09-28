using AiPrompter.Runtime.Infrastructure;
using AiPrompter.Runtime.Services;
using AiPrompter.Runtime.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

[assembly: FunctionsStartup(typeof(AiPrompter.Runtime.Program))]
namespace AiPrompter.Runtime;

internal class Program : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var appSettings = new AppSettings(new SafeConfiguration(builder.GetContext().Configuration));
        builder.Services.AddSingleton(appSettings);

        builder.Services.AddSingleton<INewsDataPollerService, NewsDataPollerService>();
    }
}
