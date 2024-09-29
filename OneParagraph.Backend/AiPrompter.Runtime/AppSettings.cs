using AiPrompter.Runtime.Infrastructure;

namespace AiPrompter.Runtime;

public class AppSettings
{
    public AppSettings(SafeConfiguration configuration)
    {
        foreach (var property in GetType().GetProperties())
        {
            property.SetValue(this, configuration[property.Name]);
        }
    }

    public string MarketauxApiBaseUrl { get; set; }
    public string MarketauxApiKey { get; set; }
    public string MarketauxApiKeyStock { get; set; }
    public string DatabaseConnectionString { get; set; }

    public string OpenApiKey { get; set; }
    public string OpenApiUrl { get; set; }
}
