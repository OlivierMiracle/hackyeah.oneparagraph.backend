using AiPrompter.Runtime.Database;
using AiPrompter.Runtime.Infrastructure;
using AiPrompter.Runtime.Services;
using AiPrompter.Runtime.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AiPrompter.Runtime.Program))]
namespace AiPrompter.Runtime;

internal class Program : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var appSettings = new AppSettings(new SafeConfiguration(builder.GetContext().Configuration));
        builder.Services.AddSingleton(appSettings);

        builder.Services.AddDbContext<DataContext>(options =>
        {
            var connectionString = appSettings.DatabaseConnectionString;
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        builder.Services.AddSingleton<INewsDataPollerService, NewsDataPollerService>();
    }
}
