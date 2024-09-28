using AiPrompter.Runtime.Services.Interfaces;
using System.Threading.Tasks;

namespace AiPrompter.Runtime.Services;

public class NewsDataPollerService : INewsDataPollerService
{
    public async Task GetNewsDataAsync()
    {
        await Task.Run(() => { });
    }
}
