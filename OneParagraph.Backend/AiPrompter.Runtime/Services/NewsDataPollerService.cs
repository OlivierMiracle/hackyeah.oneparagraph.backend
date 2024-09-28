using AiPrompter.Runtime.Services.Interfaces;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services;

public class NewsDataPollerService : INewsDataPollerService
{
    private const string GetCategorynews = "/news/all?industries=Technology&filter_entities=true&limit=10&published_after=2024-09-27T15:40&api_token=YOUR_API_TOKEN";

    private readonly AppSettings _appSettings;

    public NewsDataPollerService(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public async Task GetCategoryNews(string category)
    {
        if (category is null)
            return;

        
    }

    public async Task GetNewsDataAsync()
    {
        await Task.Run(() => { });
    }
}
